using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.Oracle;

public interface IOracle
{
    bool ShouldRebalance(DataFeed dataFeed);
    
}