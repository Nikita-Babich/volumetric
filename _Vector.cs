namespace Volumetric;

public class Vector4D
{
    private double x;
    private double y;
    private double z;
    private double w;

    public Vector4D(double x_, double y_, double z_, double w_) 
    {
        x = x_;
        y = y_;
        z = z_;
        w = w_;
    }

    public Vector4D(double[] values)
    {
        if (values.Length != 4)
            throw new ArgumentException("Array must have 4 elements for vector.");
        x = values[0];
        y = values[1];
        z = values[2];
        w = values[3];
    }

    public double Magnitude => Math.Sqrt(x * x + y * y + z * z + w * w);

    public Vector4D Normalize()
    {
        double magnitude = Magnitude;
        if (magnitude == 0)
            throw new InvalidOperationException("Cannot normalize a zero vector.");
        return new Vector4D(x / magnitude, y / magnitude, z / magnitude, w / magnitude);
    }

    public double DotProduct(Vector4D other)
    {
        return x * other.x + y * other.y + z * other.z + w * other.w;
    }

    public Vector4D Add(Vector4D other)
    {
        return new Vector4D(x + other.x, y + other.y, z + other.z, w + other.w);
    }

    public Vector4D Subtract(Vector4D other)
    {
        return new Vector4D(x - other.x, y - other.y, z - other.z, w - other.w);
    }

    public Vector4D Multiply(double scalar)
    {
        return new Vector4D(x * scalar, y * scalar, z * scalar, w * scalar);
    }

    public Vector4D Divide(double scalar)
    {
        if (scalar == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        return new Vector4D(x / scalar, y / scalar, z / scalar, w / scalar);
    }

    public double ScalarProjection(Vector4D onto)
    {
        return DotProduct(onto) / onto.Magnitude;
    }

    public Vector4D VectorProjection(Vector4D onto)
    {
        double scalarProjection = ScalarProjection(onto);
        return onto.Normalize().Multiply(scalarProjection);
    }

    // Operator Overloads
    public static Vector4D operator +(Vector4D a, Vector4D b) => a.Add(b);
    public static Vector4D operator -(Vector4D a, Vector4D b) => a.Subtract(b);
	public static Vector4D operator *(Vector4D a, Vector4D b) => a.DotProduct(b);
    public static Vector4D operator *(Vector4D a, double scalar) => a.Multiply(scalar);
    public static Vector4D operator *(double scalar, Vector4D a) => a.Multiply(scalar);
    public static Vector4D operator /(Vector4D a, double scalar) => a.Divide(scalar);

    public override string ToString() => $" Vector4D({x}, {y}, {z}, {w}) ";
}
