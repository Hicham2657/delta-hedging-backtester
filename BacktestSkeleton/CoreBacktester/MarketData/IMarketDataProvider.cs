using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.MarketData;

public interface IMarketDataProvider
{
    IEnumerable<DataFeed> GetDataFeeds();
}