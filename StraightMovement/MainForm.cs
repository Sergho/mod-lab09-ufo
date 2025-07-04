using ScottPlot;
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
    private readonly int epsilonMax = 25;
    private readonly string dataFilename = "../../../../result/data.txt";
    private readonly string plotFilename = "../../../../result/plot.png";
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
        graphics.Clear(System.Drawing.Color.White);

        if (action == SimulationAction.Idle)
        {
            drawPoints(graphics);
        }
        if (action == SimulationAction.Single)
        {
            fullSimulate(singleEpsilon, graphics);
        }
        if (action == SimulationAction.Multiple)
        {
            multipleSimulate(graphics);
            buildPlot();
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
            Thread.Sleep(action == SimulationAction.Single ? 2 : 0);
        }

        return true;
    }
    private int fullSimulate(int epsilon, Graphics g)
    {
        int n = 0;
        epsilonLabel.Text = epsilon.ToString();
        do
        {
            g.Clear(System.Drawing.Color.White);
            drawPoints(g);
            n++;
            nLabel.Text = n.ToString();
            Application.DoEvents();
            Thread.Sleep(action == SimulationAction.Single ? 100 : 0);
        }
        while (!simulate(epsilon, n, g));
        return n;
    }
    private void multipleSimulate(Graphics g)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(dataFilename) ?? "");
        File.WriteAllText(dataFilename, "");
        for(int i = 1; i <= epsilonMax; i++)
        {
            int n = fullSimulate(i, g);
            File.AppendAllText(dataFilename, $"{i}:{n}\n");
        }
    }
    private void buildPlot()
    {
        string[] lines = File.ReadAllLines(dataFilename);

        int[] x = new int[lines.Length];
        int[] y = new int[lines.Length];

        for(int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] args = line.Split(':');
            x[i] = int.Parse(args[0]);
            y[i] = int.Parse(args[1]);
        }
        
        Plot plot = new Plot();

        plot.Title($"������ ����������� N �� �������� ���������");
        plot.XLabel("�������� ���������");
        plot.YLabel("���������� ������ ���� (N)");

        var scatter = plot.Add.Scatter(x, y);
        scatter.MarkerSize = 8;
        scatter.LineWidth = 3;
        scatter.Color = Colors.Red;

        plot.SavePng(plotFilename, 1200, 800);
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

    private void multipleButton_Click(object sender, EventArgs e)
    {
        action = SimulationAction.Multiple;
        canvasPanel.Invalidate();
    }
}
