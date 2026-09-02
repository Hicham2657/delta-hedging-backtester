using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.Strategy;

public class StrategyResult
{
    public double Price {get;}
    public Dictionary<string, double> Composition {get;}
    public OutputData OutputData {get;}

    public StrategyResult(double price, Dictionary<string, double> composition, OutputData outputData)
    {
        Price = price;
        Composition = composition;
        OutputData = outputData;
    }

}