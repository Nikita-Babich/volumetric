namespace Volumetric;

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
    public double X { get; private set; }
    public double Y { get; private set; }
    public double Z { get; private set; }

    // Constructor to initialize the vector
    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Method for vector addition
    public static Vector Add(Vector a, Vector b)
    {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    // Method for vector subtraction
    public static Vector Subtract(Vector a, Vector b)
    {
        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    // Method for scalar multiplication
    public static Vector Multiply(Vector a, double scalar)
    {
        return new Vector(a.X * scalar, a.Y * scalar, a.Z * scalar);
    }

    // Method for vector cross product (vector multiplication)
    public static Vector CrossProduct(Vector a, Vector b)
    {
        return new Vector(
            a.Y * b.Z - a.Z * b.Y,
            a.Z * b.X - a.X * b.Z,
            a.X * b.Y - a.Y * b.X
        );
    }

    // Method to compute the length (magnitude) of the vector
    public double Length()
    {
        return Math.Sqrt(X * X + Y * Y + Z * Z);
    }

    // Method to normalize the vector (make it a unit vector)
    public Vector Normalize()
    {
        double length = Length();
        if (length == 0)
            throw new InvalidOperationException("Cannot normalize a zero-length vector.");
        
        return new Vector(X / length, Y / length, Z / length);
    }

    // Override ToString for easy printing
    public override string ToString()
    {
        return $"Vector({X}, {Y}, {Z})";
    }
}