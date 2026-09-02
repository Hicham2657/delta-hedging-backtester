using CoreBacktester;
using System.Text.Json;
using CoreBacktester.MarketData;
using CoreBacktester.Strategy;


var testParams = TestParametersReader.Read(args[0]);
IMarketDataProvider provider = new CsvMarketDataProvider(args[1]);

IStrategy strategy = new DeltaHedgingStrategy(testParams);

var backtester = new Backtester(provider, testParams, strategy);
var outputs = backtester.RunBacktest();

var options = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    WriteIndented = true
};

File.WriteAllText(args[2], JsonSerializer.Serialize(outputs, options));
