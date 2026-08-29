using System.Text.Json;
using PricingLibrary.DataClasses;
using PricingLibrary.RebalancingOracleDescriptions;

namespace CoreBacktester.MarketData;

public static class TestParametersReader
{
    public static BasketTestParameters Read(string path)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new RebalancingOracleDescriptionConverter() }
        };

        return JsonSerializer.Deserialize<BasketTestParameters>(File.ReadAllText(path), options)!;
    }
}