namespace CoreBacktester.Oracle;

public interface IOracle
{
    bool ShouldRebalance(DateTime currentDate, double[] currentSpots);
    
}