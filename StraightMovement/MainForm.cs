namespace StraightMovement;

public partial class MainForm : Form
{
    private readonly Point fromPoint = new Point(200, 600);
    private readonly Point toPoint = new Point(800, 300);
    private readonly int pointSize = 20;
    public MainForm()
    {
        InitializeComponent();

        updateLabels();
    }

    private void canvasPanel_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        graphics.ScaleTransform(0.5f, 0.5f);
        graphics.Clear(Color.White);

        drawPoints(graphics);
    }
    private void drawPoints(Graphics g)
    {
        g.FillEllipse(Brushes.Green, fromPoint.X, fromPoint.Y, pointSize, pointSize);
        g.FillEllipse(Brushes.Red, toPoint.X, toPoint.Y, pointSize, pointSize);
    }
    private void updateLabels()
    {
        fromLabel.Text = fromPoint.ToString();
        toLabel.Text = toPoint.ToString();
    }
}
