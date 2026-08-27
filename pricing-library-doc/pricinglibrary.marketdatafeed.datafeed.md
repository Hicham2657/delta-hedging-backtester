# DataFeed

Namespace: PricingLibrary.MarketDataFeed

Represents a market data feed at a given date.

```csharp
public class DataFeed
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [DataFeed](./pricinglibrary.marketdatafeed.datafeed.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **PriceList**

Readonly property containing the prices of the datafeed.

```csharp
public Dictionary<string, double> PriceList { get; }
```

#### Property Value

[Dictionary&lt;String, Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>

### **Date**

Readonly property containing the date of the datafeed.

```csharp
public DateTime Date { get; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

## Constructors

### **DataFeed(DateTime, Dictionary&lt;String, Double&gt;)**

Constructor for the datafeed class.

```csharp
public DataFeed(DateTime date, Dictionary<string, double> priceList)
```

#### Parameters

`date` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
Date for the data feed.

`priceList` [Dictionary&lt;String, Double&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2)<br>
Price list of the data feed.
