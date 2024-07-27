namespace Volumetric;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
		this.Size = new Size(400, 400);
    }
	
	protected override void OnPaint(PaintEventArgs e)
	{
		base.OnPaint(e);
		Graphics g = e.Graphics;

		DrawSquare(g, 50, 50, 100, Color.LightBlue, Color.Black);
		DrawSquare(g, 200, 50, 150, Color.Green, Color.Red);
	}
	
	private void DrawSquare(Graphics g, int x, int y, int size, Color fillColor, Color borderColor)
	{
		// Create a brush for filling the square
		using (Brush brush = new SolidBrush(fillColor))
		{
			// Fill the square
			g.FillRectangle(brush, x, y, size, size);
		}
	}
	
}
