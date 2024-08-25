namespace Volumetric;

public class Camera
{
    public Vector4D pos { get; private set; }
    public Vector4D right { get; private set; }
    public Vector4D forward { get; private set; }
    public Vector4D up { get; private set; }
	
	public Camera()
    {
        pos = new Vector4D(0, 0, 0, 0);          // Default position at origin
        right = new Vector4D(1, 0, 0, 0);        // Aligned with x-axis
        forward = new Vector4D(0, 1, 0, 0);      // Aligned with y-axis
        up = new Vector4D(0, 0, 0, 1);           // Aligned with w-axis Global vertical
    }
	
    public Camera(Vector4D pos_, Vector4D right_, Vector4D forward_, Vector4D up_)
    {
        pos = pos_;
        right = right_;
        forward = forward_;
        up = up_;
    }

    // Method to rotate the camera's orientation vectors using a rotation matrix
    public void Rotate(Matrix4D rotationMatrix)
    {
        right = rotationMatrix.Transform(right);
        forward = rotationMatrix.Transform(forward);
        up = rotationMatrix.Transform(up);
    }

    // Method to move the camera relative to its local axes
    public void MoveRelative(double right_, double forward_, double up_)
    {
        pos = pos.Add(right.Multiply(right_))
                 .Add(forward.Multiply(forward_))
                 .Add(up.Multiply(up_));
    }

    // Method to move the camera relative to the world axes
    public void MoveAbsolute(double x_, double y_, double z_, double w_)
    {
        pos = pos.Add(new Vector4D(x_, y_, z_, w_));
    }

    public override string ToString()
    {
        return $"Camera: pos={pos}\t right={right}\t forward={forward}\t up={up}\n";
    }
}
