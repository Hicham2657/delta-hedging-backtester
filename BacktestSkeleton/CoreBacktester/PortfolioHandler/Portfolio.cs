using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.PortfolioHandler;

public class Portfolio
{
    private Dictionary<string, double> _positions;
    private double _cash;
    private DateTime _updateDate;

    private double WeightedSum(Dictionary<string, double> priceList)
    {
        double sum = 0.0;
        foreach(var position in _positions)
        {
            sum+= position.Value * priceList[position.Key];
        }
        return sum;
    }

    public Portfolio(double initialPrice, Dictionary<string, double> initialPositions, DataFeed initialFeed)
    {
        _positions = new Dictionary<string, double>(initialPositions);
        _cash = initialPrice - WeightedSum(initialFeed.PriceList);
        _updateDate = initialFeed.Date;
    }

    public double Value(DataFeed dataFeed)
    {
        double compoundedCash = _cash * RiskFreeRateProvider.GetRiskFreeRateAccruedValue(_updateDate, dataFeed.Date);
        return  compoundedCash + WeightedSum(dataFeed.PriceList);
    }

    public void UpdateCompo(DataFeed currentFeed, Dictionary<string, double> newPositions)
    {
        double oldValue = Value(currentFeed);
        _positions = new Dictionary<string, double>(newPositions);
        _cash = oldValue - WeightedSum(currentFeed.PriceList);
        _updateDate = currentFeed.Date;
    }
}