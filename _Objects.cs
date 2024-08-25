namespace Volumetric;

public abstract class Object4D
{
    public Vector4D pos { get; protected set; }   // Position of the object
    public Color color { get; protected set; }   // Color of the object (could be improved with a Color class)
    public Matrix4D? rotation { get; protected set; } // Rotation of the object

    protected Object4D(Vector4D pos_, Matrix4D rotation_, Color color_)
    {
        pos = pos_;
        color = color_;
        rotation = rotation_;
    }
	
	public abstract bool Inside(Vector4D point);
	public abstract Vector4D? Intersect(Ray4D ray);
	
	public override string ToString()
    {
        return $"Position: {pos}\nColor: {color}\nRotation Matrix:\n{rotation}";
    }
}

public class Sphere4D : Object4D
{
    public double radius { get; private set; }

    public Sphere4D(Vector4D pos_, double radius_, Color color_)
    {
		pos = pos_;
		color = color_;
        radius = radius_;
    }

    public override bool Inside(Vector4D point)
    {
        // Check if the distance from the point to the sphere's center is less than or equal to the radius
        return pos.Subtract(point).Magnitude <= Radius;
    }

    public override Vector4D? Intersect(Ray4D ray) //\\
    {
        // Implementing a 4D sphere-ray intersection algorithm

        Vector4D oc = ray.pos.Subtract(pos);
        double a = ray.dir.DotProduct(ray.dir);
        double b = 2.0 * oc.DotProduct(ray.dir);
        double c = oc.DotProduct(oc) - Radius * Radius;

        double discriminant = b * b - 4 * a * c;
        if (discriminant < 0)
        {
            return null; // No intersection
        }

        // Calculate the two potential intersection points (roots)
        double t1 = (-b - Math.Sqrt(discriminant)) / (2.0 * a);
        double t2 = (-b + Math.Sqrt(discriminant)) / (2.0 * a);

        // We return the first positive intersection (smallest t)
        double t = (t1 > 0) ? t1 : (t2 > 0) ? t2 : -1;
        if (t < 0) return null; // If both t1 and t2 are negative, there's no valid intersection

        return ray.pos.Add(ray.dir.Multiply(t));
    }

    public override string ToString()
    {
        return base.ToString() + $"\nRadius: {Radius}";
    }
}