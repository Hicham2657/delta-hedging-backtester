using CoreBacktester.Oracle;
using PricingLibrary.MarketDataFeed;
using PricingLibrary.RebalancingOracleDescriptions;

namespace CoreBacktester.Oracle;

static class OracleFactory
{
    public static IOracle CreateOracle(IRebalancingOracleDescription description, DataFeed initialFeed)
    {
        if (description is RegularOracleDescription regular)
        {
            return new RegularOracle(regular.Period, initialFeed.Date);
        }
        else if (description is SpotOracleDescription spot)
        {
            return new SpotOracle(spot.Threshold, initialFeed);
        }
        throw new ArgumentException($"Unsupported oracle description: {description.GetType().Name}");
    }
}