using PricingLibrary.TimeHandler;

namespace CoreBacktester.Oracle;

public class RegularOracle : IOracle
{
    private readonly int _period;
    private DateTime _lastRebalanceDate;

    public RegularOracle(int period, DateTime lastRebalanceDate)
    {
        _period = period;
        _lastRebalanceDate = lastRebalanceDate;
    }

    public bool ShouldRebalance(DateTime currentDate, double[] currentSpots)
    {
        if (MathDateConverter.ConvertToMathDistance(_lastRebalanceDate, currentDate)*252 >= _period)
        {
            _lastRebalanceDate = currentDate;
            return true;
        }
        return false;
    }
}