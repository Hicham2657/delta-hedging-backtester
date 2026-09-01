namespace CoreBacktester.Oracle;

public class SpotOracle : IOracle
{
    private readonly double _threshold;
    private double[] _lastSpots;

    public SpotOracle(double threshold, double[] initialSpots)
    {
        _threshold = threshold;
        _lastSpots = initialSpots.ToArray();
    }

    public bool ShouldRebalance(DateTime currentDate, double[] currentSpots)
    {
        for (int i = 0; i < currentSpots.Length; i++)
        {
            if (Math.Abs(currentSpots[i] - _lastSpots[i]) / _lastSpots[i] > _threshold)
            {
                _lastSpots = currentSpots.ToArray();
                return true;
            }
        }
        return false;

    }

}