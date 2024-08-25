namespace Volumetric;

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