using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.PortfolioHandler;

public class Portfolio
{
    private double[] _deltas;
    private double _cash;
    private DateTime _lastUpdate;

    private double WeightedSum(double[] spots)
    {
        return spots.Zip(_deltas, (u,v) => u*v).Sum();
    }

    public Portfolio(double initialPrice, double[] initialSpots, double[] initialDeltas, DateTime initialDate)
    {
        _deltas = initialDeltas.ToArray();
        _cash = initialPrice - WeightedSum(initialSpots);
        _lastUpdate = initialDate;
    }

    public void UpdatePortfolio(DateTime newTime)
    {
        _cash *= RiskFreeRateProvider.GetRiskFreeRateAccruedValue(_lastUpdate, newTime);
        _lastUpdate = newTime;
    }

    public double Value(double[] spots)
    {
        return _cash + WeightedSum(spots);
    }

    public void UpdateCompo(double[] spots, double[] newDeltas)
    {
        double oldValue = Value(spots);
        _deltas = newDeltas.ToArray();
        _cash = oldValue - WeightedSum(spots);
    }
}