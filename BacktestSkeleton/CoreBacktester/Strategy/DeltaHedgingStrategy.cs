using PricingLibrary.Computations;
using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.Strategy;

public class DeltaHedgingStrategy : IStrategy
{
    private readonly Pricer _pricer;

    public DeltaHedgingStrategy(BasketTestParameters testParams)
    {
        _pricer = new Pricer(testParams);
    }

    private double[] GetOrderedSpots(DataFeed dataFeed)
    {
        return _pricer.UnderlyingShareIds.Select(id => dataFeed.PriceList[id]).ToArray();
    }

    private Dictionary<string, double> GetPositions(double[] deltas)
    {
        Dictionary<string, double> res = new Dictionary<string, double>();
        for(int i =0; i<_pricer.UnderlyingShareIds.Length; ++i)
        {
            res[_pricer.UnderlyingShareIds[i]] = deltas[i];
        }
        return res;
    }

    public StrategyResult GetStrategyResult(DataFeed currentFeed, double currentPortfolioValue)
    {
        PricingResults pricingResults = _pricer.Price(currentFeed.Date, GetOrderedSpots(currentFeed));
        double price = pricingResults.Price;
        Dictionary<string, double> composition = GetPositions(pricingResults.Deltas);
        OutputData outputData = new OutputData
        {
            Date = currentFeed.Date,
            Deltas = pricingResults.Deltas,
            DeltasStdDev = pricingResults.DeltaStdDev,
            Price = pricingResults.Price,
            PriceStdDev = pricingResults.PriceStdDev,
            TransactionCosts = 0.0,
            Value = currentPortfolioValue
        };
        return new StrategyResult(price, composition, outputData);
        
    }
}