namespace Volumetric;

public abstract class Object4D
{
    public Vector4D pos { get; protected set; }   // Position of the object
    public string color { get; protected set; }   // Color of the object (could be improved with a Color class)
    public Matrix4D rotation { get; protected set; } // Rotation of the object

    protected Object4D(Vector4D pos_, string color_, Matrix4D rotation_)
    {
        pos = pos_;
        color = color_;
        rotation = rotation_;
    }
	
}