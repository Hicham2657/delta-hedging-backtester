namespace CoreBacktester;
using Oracle;
using MarketData;
using PricingLibrary.Computations;
using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;
using PortfolioHandler;
using PricingLibrary.RebalancingOracleDescriptions;

public class Backtester
{
    private readonly List<DataFeed> _dataFeeds;
    private readonly Pricer _pricer;
    private readonly IOracle _oracle;

    public Backtester(IMarketDataProvider provider, BasketTestParameters testParams)
    {
        _dataFeeds = provider.GetDataFeeds().ToList();
        _pricer = new Pricer(testParams);    

        RegularOracleDescription oracleDescription = testParams.RebalancingOracleDescription as RegularOracleDescription;
        _oracle = new RegularOracle(oracleDescription.Period, _dataFeeds.First().Date);
    }

    private double[] GetSpots(DataFeed dataFeed)
    {
        return _pricer.UnderlyingShareIds.Select(id => dataFeed.PriceList[id]).ToArray();
    }

    private OutputData CreateOutputData(DateTime date, PricingResults pricingResults, double portfolioValue)
    {
        return new OutputData
        {
            Date = date,
            Deltas = pricingResults.Deltas,
            DeltasStdDev = pricingResults.DeltaStdDev,
            Price = pricingResults.Price,
            PriceStdDev = pricingResults.PriceStdDev,
            TransactionCosts = 0.0,
            Value = portfolioValue
        };
    }

    public List<OutputData> RunBacktest()
    {
        DateTime initialDate = _dataFeeds.First().Date;
        double[] initialSpots = GetSpots(_dataFeeds.First());
        PricingResults results = _pricer.Price(initialDate, initialSpots);
        double initialPrice = results.Price;
        double[] initialDeltas = results.Deltas;
        Portfolio portfolio = new Portfolio(initialPrice, initialSpots, initialDeltas, initialDate);

        List<OutputData> outputs = [CreateOutputData(initialDate, results, portfolio.Value(initialSpots))];

        foreach(DataFeed currentFeed in _dataFeeds.Skip(1)){
            
            DateTime currentDate = currentFeed.Date;
            double[] spots = GetSpots(currentFeed);
            portfolio.UpdatePortfolio(currentDate);

            if (_oracle.ShouldRebalance(currentDate, spots))
            {
                results = _pricer.Price(currentDate, spots);
                double[] newDeltas = results.Deltas;
                portfolio.UpdateCompo(spots, newDeltas);
            
                outputs.Add(CreateOutputData(currentDate, results, portfolio.Value(spots)));
            }
        }
        return outputs;
    }
}