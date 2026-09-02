namespace CoreBacktester;
using Oracle;
using MarketData;
using PricingLibrary.DataClasses;
using PricingLibrary.MarketDataFeed;
using PortfolioHandler;
using CoreBacktester.Strategy;

public class Backtester
{
    private readonly List<DataFeed> _dataFeeds;
    private readonly IStrategy _strategy;
    private readonly IOracle _oracle;

    public Backtester(IMarketDataProvider provider, BasketTestParameters testParams, IStrategy strategy)
    {
        _dataFeeds = provider.GetDataFeeds().ToList();
        _strategy = strategy;
        _oracle = OracleFactory.CreateOracle(testParams.RebalancingOracleDescription, _dataFeeds.First());
    }

    public List<OutputData> RunBacktest()
    {
        DataFeed initialFeed = _dataFeeds.First();
        
        StrategyResult initialResults = _strategy.GetStrategyResult(initialFeed, 0);
        double initialPortfolioPrice = initialResults.Price;

        Dictionary<string, double> initialComposition = initialResults.Composition;
        Portfolio portfolio = new Portfolio(initialPortfolioPrice, initialComposition, initialFeed);

        OutputData initialOutput = initialResults.OutputData;
        initialOutput.Value = initialPortfolioPrice;
        List<OutputData> outputs = [initialOutput];

        foreach(DataFeed currentFeed in _dataFeeds.Skip(1))
        {
            if (_oracle.ShouldRebalance(currentFeed))
            {
                StrategyResult strategyResult = _strategy.GetStrategyResult(currentFeed, portfolio.Value(currentFeed));
                portfolio.UpdateCompo(currentFeed, strategyResult.Composition);
                outputs.Add(strategyResult.OutputData);
            }
        }
        return outputs;
    }
}