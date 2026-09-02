using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.Strategy;

public interface IStrategy
{
    StrategyResult GetStrategyResult(DataFeed currentFeed, double currentPortfolioValue);
}