namespace Volumetric;

public class Object
{
	public Vector center;
	public Color color;
	private Vector[] faces;
	
	public Object(Vector center_, Color color_)
	{
		center = center_;
		color = color_;
	}
	
	public virtual bool Inside(Vector point)
	{
		foreach (var n in faces)
		{
			// if projection on normal is not less than normal length, then point is outside
			//if(!(Vector.Projection(Vector.Substract(point, center), n) < n.Length())){
			if (  ((point-center)%n).Length() > n.Length() ){
				return false;
			}
		}
		return true;
	}
	
	// public Vector Intersection(Ray ray)
	// {
		// https://en.wikipedia.org/wiki/Line%E2%80%93plane_intersection#Parametric_form
		// Vector result;
		// foreach (var n in faces)
		// {
			// Vector plane_center = Vector.Add(center, n);
			
			// double d = Vector.DotProduct(Vector.Subtract(plane_center, ray.origin), n) /
				// Vector.DotProduct(ray.direction, n);
			//if slightly further point is inside then return
			//Vector further = Vector.Add(
		// }
	// }
}

// public class Sphere: Object
// {
	
// }