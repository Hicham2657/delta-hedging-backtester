using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.MarketData;

public class CsvMarketDataProvider : IMarketDataProvider
{
    private readonly string _path;

    public CsvMarketDataProvider(string path)
    {
        _path = path;
    }

    public IEnumerable<DataFeed> GetDataFeeds()
    {
        List<ShareValue> values = MarketDataReader.ReadShareValues(_path);
        return MarketDataReader.ToDataFeeds(values);
    }
}