namespace Volumetric;

public class Ray4D
{
    public Vector4D pos { get; private set; } // Position of the ray's origin
    public Vector4D dir { get; private set; } // Direction of the ray
	public Vector4D? hit { get; private set; }
	public Color? color;

    public Ray4D(Vector4D pos_, Vector4D dir_)
    {
        pos = pos_;
        dir = dir_.Normalize();
    }
	
	public Ray4D(int xpixel, int ypixel)
    {
        // convert pixels to vectors and call previous constructor
    }
	
}