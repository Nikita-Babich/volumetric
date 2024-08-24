namespace Volumetric;

using System.Drawing;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }    
}

public class Vector
{
    // Properties for the vector components
    public double x { get; private set; }
    public double y { get; private set; }
    public double z { get; private set; }

    // Constructor to initialize the vector
    public Vector(double x_, double y_, double z_)
    {
        x = x_;
        y = y_;
        z = z_;
    }
	
	// Override ToString for easy printing
    public override string ToString(){
        return $" Vector({x}, {y}, {z}) ";
    }
	
    public double Length(){
        return Math.Sqrt(x * x + y * y + z * z);
    }
	
    // Making unit vector
    public Vector Norm() //normalized
    {
        double length = Length();
        if (length == 0)
            throw new InvalidOperationException("Cannot normalize a zero-length vector.");
        
        return new Vector(x / length, y / length, z / length);
    }
	
	public static Vector operator +(Vector a, Vector b) =>
		new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
		
	public static Vector operator -(Vector a, Vector b) =>
		new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
		
	public static Vector operator *(double m, Vector a) =>
		new Vector(a.x * m, a.y * m, a.z * m);
		
	public static Vector operator *(Vector a, double m) =>
		m*a;
		
	public static double operator *(Vector a, Vector b) =>
		a.x * b.x + a.y * b.y + a.z * b.z;
		
	// % Cross product
	public static Vector operator %(Vector a, Vector b) =>
		new Vector(
            a.y * b.z - a.z * b.y,
            a.z * b.x - a.x * b.z,
            a.x * b.y - a.y * b.x
        );
	
	public static Vector Projection(Vector a, Vector b){
		double bLengthSquared = b.x * b.x + b.y * b.y + b.z * b.z;
		if (bLengthSquared == 0)
			throw new InvalidOperationException("Cannot project onto a zero-length vector.");

		double dotProduct = a.x * b.x + a.y * b.y + a.z * b.z;
		double scale = dotProduct / bLengthSquared;

		return new Vector(b.x * scale, b.y * scale, b.z * scale);
	}
	public static Vector operator /(Vector a, Vector b){
		return Projection(a, b);
	}

}

public class Ray //to shoot in a pixel direction from a player
{
	public Vector origin;
	public Vector direction;
	public Vector? collision;
	
	public Ray(Vector origin_, Vector dir_)
	{
		origin = origin_;
		direction = dir_;
	}
}

public static class Grid //might be remade in Form
{
	public static int width;
	public static int height;
	public static int width_segments;
	public static int height_segments;
	private static Color[,] values;
	
	public static void Create(int ws, int hs)
	{
		width_segments = ws;
		height_segments = hs;
		values = new Color[hs, ws]; // old values are reclaimed by garbage collector
		
	}
	
	public static void Evaluate() //calcalate all values in the given environment
	{
		for (int i = 0; i < height_segments; i++)
        {
            for (int j = 0; j < width_segments; j++)
			{
				//find the direction ray
				//Call function for intersections
				//Vector ray = Ray.Shoot(Player, i,j);
				//values[i,j] = Ray.Cast(
			}
		}
	}
	
	public static void Draw() //draw rectangles on the Form1
	{
		for (int i = 0; i < height_segments; i++)
        {
            for (int j = 0; j < width_segments; j++)
			{
				Form1.DrawBlock(i,j);//no reference recieved
			}
		}
	}
	
}

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

public class Quaternion
{
	public double r { get; private set; }
	public double x { get; private set; }
    public double y { get; private set; }
    public double z { get; private set; }
	
	public Quaternion(double r_, double x_, double y_, double z_)
    {
		r = r_;
        x = x_;
        y = y_;
        z = z_;
    }
	
	public override string ToString(){
        return $" Quaternion({r}, {x}, {y}, {z}) ";
    }
	
}