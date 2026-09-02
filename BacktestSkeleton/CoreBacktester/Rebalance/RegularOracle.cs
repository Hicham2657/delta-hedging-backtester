using PricingLibrary.MarketDataFeed;
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

    public bool ShouldRebalance(DataFeed dataFeed)
    {
        if (MathDateConverter.ConvertToMathDistance(_lastRebalanceDate, dataFeed.Date)*252 >= _period)
        {
            _lastRebalanceDate = dataFeed.Date;
            return true;
        }
        return false;
    }
}