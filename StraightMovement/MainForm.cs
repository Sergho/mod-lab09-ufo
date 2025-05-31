using System.Drawing;
using System.Runtime.ExceptionServices;

namespace StraightMovement;

public partial class MainForm : Form
{
    private readonly Point fromPoint = new Point(200, 1000);
    private readonly Point toPoint = new Point(500, 200);
    private readonly int pointSize = 20;
    private readonly int pathSize = 5;
    private readonly int stepSize = 5;
    private readonly int singleEpsilon = 1;
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

        if (action == SimulationAction.Idle)
        {
            drawPoints(graphics);
        }
        if (action == SimulationAction.Single)
        {
            fullSimulate(singleEpsilon, graphics);
        }

        action = SimulationAction.Idle;
    }
    private void drawPoint(PointF point, int size, Graphics g, Brush brush)
    {
        g.FillEllipse(brush, point.X - (float)size / 2, point.Y - (float)size / 2, size, size);
    }
    private void drawPoints(Graphics g)
    {
        drawPoint(fromPoint, pointSize, g, Brushes.Green);
        drawPoint(toPoint, pointSize, g, Brushes.Red);
    }
    private void updateLabels()
    {
        fromLabel.Text = fromPoint.ToString();
        toLabel.Text = toPoint.ToString();
    }
    private bool simulate(int epsilon, int n, Graphics g)
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
            Thread.Sleep(2);
        }

        return true;
    }
    private int fullSimulate(int epsilon, Graphics g)
    {
        int n = 0;
        epsilonLabel.Text = epsilon.ToString();
        do
        {
            g.Clear(Color.White);
            drawPoints(g);
            n++;
            nLabel.Text = n.ToString();
            Application.DoEvents();
            Thread.Sleep(100);
        }
        while (!simulate(epsilon, n, g));
        return n;
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
