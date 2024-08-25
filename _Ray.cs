namespace Volumetric;

public class Ray4D
{
    public Vector4D pos { get; private set; } // Position of the ray's origin
    public Vector4D dir { get; private set; } // Direction of the ray

    public Ray4D(Vector4D pos_, Vector4D dir_)
    {
        pos = pos_;
        dir = dir_.Normalize(); // Ensure direction is normalized
    }
	
}