using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.Oracle;

public class SpotOracle : IOracle
{
    private readonly double _threshold;
    private DataFeed _lastFeed;

    public SpotOracle(double threshold, DataFeed initialFeed)
    {
        _threshold = threshold;
        _lastFeed = initialFeed;
    }

    public bool ShouldRebalance(DataFeed currentFeed)
    {
        foreach (var current in currentFeed.PriceList)
        {
            double lastPrice = _lastFeed.PriceList[current.Key];
            if (Math.Abs(current.Value - lastPrice) / lastPrice > _threshold)
            {
                _lastFeed = currentFeed;
                return true;
            }
        }

        return false;

    }

}