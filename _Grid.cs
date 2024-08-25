namespace Volumetric;

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