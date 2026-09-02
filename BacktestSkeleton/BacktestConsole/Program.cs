using CoreBacktester;
using System.Text.Json;
using CoreBacktester.MarketData;
using CoreBacktester.Strategy;

// Console.WriteLine("Testing that the PricingLibrary Nuget package is correctly accessed");
// var distance = PricingLibraryTest.TestMathDateConverter();
// Console.WriteLine($"Read value {distance}");
// Console.ReadKey();

var testParams = TestParametersReader.Read(args[0]);
IMarketDataProvider provider = new CsvMarketDataProvider(args[1]);
// var shareValues = MarketDataReader.ReadShareValues(args[1]);
// var feeds = provider.GetDataFeeds();

// Console.WriteLine($"Strike: {testParams.BasketOption.Strike}");
// Console.WriteLine($"Maturity: {testParams.BasketOption.Maturity:yyyy-MM-dd}");
// Console.WriteLine($"Oracle: {testParams.RebalancingOracleDescription.Type}");
// Console.WriteLine($"ShareValues: {shareValues.Count}, DataFeeds: {feeds.Count()}");
// Console.WriteLine($"From {feeds.First().Date:yyyy-MM-dd} to {feeds.Last().Date:yyyy-MM-dd}");

// Backtester boucle = new Backtester(provider, testParams);
// boucle.RunBacktest();

IStrategy strategy = new DeltaHedgingStrategy(testParams);

var backtester = new Backtester(provider, testParams, strategy);
var outputs = backtester.RunBacktest();

var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

File.WriteAllText(args[2], JsonSerializer.Serialize(outputs, options));
Console.WriteLine("dfbvd");