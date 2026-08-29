using System.Globalization;
using PricingLibrary.MarketDataFeed;

namespace CoreBacktester.MarketData;

public static class MarketDataReader
{
    private const string DateFormat = "MM/dd/yyyy HH:mm:ss";

    public static List<ShareValue> ReadShareValues(string path)
    {
        var values = new List<ShareValue>();

        foreach (var line in File.ReadLines(path).Skip(1))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var fields = line.Split(',');
            values.Add(new ShareValue
            {
                Id = fields[0],
                DateOfPrice = DateTime.ParseExact(fields[1], DateFormat, CultureInfo.InvariantCulture),
                Value = double.Parse(fields[2], CultureInfo.InvariantCulture)
            });
        }

        return values;
    }

    public static List<DataFeed> ToDataFeeds(IEnumerable<ShareValue> values)
    {
        return values
            .GroupBy(v => v.DateOfPrice)
            .OrderBy(g => g.Key)
            .Select(g => new DataFeed(g.Key, g.ToDictionary(v => v.Id, v => v.Value)))
            .ToList();
    }
}