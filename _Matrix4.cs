namespace Volumetric;

public class Matrix4D
{
	public double[,] matrix {get; private set;} ;
	
	public Matrix4D()
    {
        matrix = new double[4, 4];
        for (int i = 0; i < 4; i++) matrix[i, i] = 1; // Initialize as identity matrix
    }
	
	public Matrix4D(double[,] matrix_)
    {
		if(matrix_.GetLength(0)!=4 || matrix_.GetLength(1)!=4) 
			throw new  ArgumentException("wrong size of matrix arg");
		matrix=matrix_;
	}
	
	public static Matrix4D RotationXY(double theta)
    {
        double[,] rotationMatrix = {
            { Math.Cos(theta), -Math.Sin(theta), 0, 0 },
            { Math.Sin(theta),  Math.Cos(theta), 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        };
        return new Matrix4D(rotationMatrix);
    }
	
	public static Matrix4D RotationXZ(double theta)
    {
        double[,] rotationMatrix = {
            { Math.Cos(theta), 0, -Math.Sin(theta), 0 },
            { 0, 1, 0, 0 },
            { Math.Sin(theta), 0,  Math.Cos(theta), 0 },
            { 0, 0, 0, 1 }
        };
        return new Matrix4D(rotationMatrix);
    }

    public static Matrix4D RotationXW(double theta)
    {
        double[,] rotationMatrix = {
            { Math.Cos(theta), 0, 0, -Math.Sin(theta) },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { Math.Sin(theta), 0, 0,  Math.Cos(theta) }
        };
        return new Matrix4D(rotationMatrix);
    }

    public static Matrix4D RotationYZ(double theta)
    {
        double[,] rotationMatrix = {
            { 1, 0, 0, 0 },
            { 0, Math.Cos(theta), -Math.Sin(theta), 0 },
            { 0, Math.Sin(theta),  Math.Cos(theta), 0 },
            { 0, 0, 0, 1 }
        };
        return new Matrix4D(rotationMatrix);
    }

    public static Matrix4D RotationYW(double theta)
    {
        double[,] rotationMatrix = {
            { 1, 0, 0, 0 },
            { 0, Math.Cos(theta), 0, -Math.Sin(theta) },
            { 0, 0, 1, 0 },
            { 0, Math.Sin(theta), 0,  Math.Cos(theta) }
        };
        return new Matrix4D(rotationMatrix);
    }

    public static Matrix4D RotationZW(double theta)
    {
        double[,] rotationMatrix = {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, Math.Cos(theta), -Math.Sin(theta) },
            { 0, 0, Math.Sin(theta),  Math.Cos(theta) }
        };
        return new Matrix4D(rotationMatrix);
    }
	
	public double[] Transform(double[] vector_)
    {
        if (vector_.Length != 4)
            throw new ArgumentException("Vector must have 4 elements for Transform.");

        double[] result = new double[4];

        for (int i = 0; i < 4; i++)
        {
            result[i] = 0;
            for (int j = 0; j < 4; j++)
            {
                result[i] += matrix[i, j] * vector_[j];
            }
        }

        return result;
    }
	
	public static Matrix4D operator *(Matrix4D a, Matrix4D b)
    {
        double[,] result = new double[4, 4];

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < 4; k++)
                {
                    result[i, j] += a.matrix[i, k] * b.matrix[k, j];
                }
            }
        }

        return new Matrix4D(result);
    }
}