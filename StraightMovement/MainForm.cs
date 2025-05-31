using System.Runtime.ExceptionServices;

namespace StraightMovement;

public partial class MainForm : Form
{
    private readonly Point fromPoint = new Point(200, 1000);
    private readonly Point toPoint = new Point(500, 200);
    private readonly int pointSize = 20;
    private readonly int pathSize = 5;
    private readonly int stepSize = 5;
    private readonly int singleEpsilon = 5;
    private SimulationAction action = SimulationAction.Idle;
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

        drawPoint(fromPoint, pointSize, graphics, Brushes.Green);
        drawPoint(toPoint, pointSize, graphics, Brushes.Red);

        if (action == SimulationAction.Single)
        {
            epsilonLabel.Text = singleEpsilon.ToString();
            Simulate(singleEpsilon, 1, graphics);
        }

        action = SimulationAction.Idle;
    }
    private void drawPoint(PointF point, int size, Graphics g, Brush brush)
    {
        g.FillEllipse(brush, point.X - (float)size / 2, point.Y - (float)size / 2, size, size);
    }
    private void updateLabels()
    {
        fromLabel.Text = fromPoint.ToString();
        toLabel.Text = toPoint.ToString();
    }
    private bool Simulate(int epsilon, int n, Graphics g)
    {
        double angle = FunctionManager.atan((double)Math.Abs(toPoint.Y - fromPoint.Y) / Math.Abs(toPoint.X - fromPoint.X), n);
        PointF current = fromPoint;
        double distance = getDistance(current, toPoint);

        while (distance > epsilon)
        {
            current.X += (float)(stepSize * FunctionManager.cos(angle, n));
            current.Y -= (float)(stepSize * FunctionManager.sin(angle, n));
            drawPoint(current, pathSize, g, Brushes.Blue);
            double newDistance = getDistance(current, toPoint);
            if (newDistance > distance) return false;
            distance = newDistance;
        }

        return true;
    }
    private double getDistance(PointF first, PointF second)
    {
        return Math.Sqrt(Math.Pow(first.X - second.X, 2) + Math.Pow(first.Y - second.Y, 2));
    }

    private void singleButton_Click(object sender, EventArgs e)
    {
        action = SimulationAction.Single;
        canvasPanel.Invalidate();
    }
}
