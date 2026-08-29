namespace CoreBacktester;
using MarketData;
using PricingLibrary.Computations;
using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;

public class Backtester
{
    private readonly List<DataFeed> _dataFeeds;
    private readonly BasketTestParameters _testParameters;
    private readonly Pricer _pricer;

    public Backtester(IMarketDataProvider provider, BasketTestParameters testparams)
    {
        _dataFeeds = provider.GetDataFeeds().ToList();
        _testParameters = testparams;
        _pricer = new Pricer(_testParameters);
    }
    
    public void PrintPrices()
    {
        foreach(var dataFeed in _dataFeeds)
        {
            DateTime date = dataFeed.Date;
            Double[] spots = _pricer.UnderlyingShareIds.Select(id => dataFeed.PriceList[id]).ToArray();
            PricingResults results = _pricer.Price(date, spots);
            Console.WriteLine(results.Price);
        }
    }
}