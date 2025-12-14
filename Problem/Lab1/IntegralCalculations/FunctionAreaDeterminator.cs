using Problem.Lab1.IntegralCalculations;

public abstract class FunctionAreaDeterminator
{
    protected double _startPosition = 0;
    protected double _endPosition;
    protected int _numberOfIterations;
    protected List<double> XPoints = new List<double>();
    protected List<double> YPoints = new List<double>();

    public double StartPosition
    {
        get => _startPosition;
        set
        {
            if (value > _endPosition) throw new ArgumentException("Start position cannot exceed end position");
            _startPosition = value;
        }
    }

    public double EndPosition
    {
        get => _endPosition;
        set
        {
            if (value < _startPosition) throw new ArgumentException("End position cannot be less than start position");
            _endPosition = value;
        }
    }

    public int NumberOfIterations
    {
        get => _numberOfIterations;
        set
        {
            if (value < 1) throw new ArgumentException("Number of iterations must be positive");
            _numberOfIterations = value;
        }
    }

    public IProgress<double>? Progress { get; set; }
    public List<double> GetXPoints() => XPoints;
    public List<double> GetYPoints() => YPoints;
    public abstract double GetIntegral(IntegralMethodRequest integralMethodRequest);
}