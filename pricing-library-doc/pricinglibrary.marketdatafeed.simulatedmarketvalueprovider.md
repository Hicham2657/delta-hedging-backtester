# SimulatedMarketValueProvider

Namespace: PricingLibrary.MarketDataFeed

Provider that returns a list of market values between two arbitrary business dates.

```csharp
public static class SimulatedMarketValueProvider
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SimulatedMarketValueProvider](./pricinglibrary.marketdatafeed.simulatedmarketvalueprovider.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Methods

### **GetShareValues(String[], DateTime, DateTime, Double[], Double[][], Double)**

Generates a list of market values generated using the Black-Scholes model and throws an exception if the start or
 end dates are not business days.

```csharp
public static List<ShareValue> GetShareValues(String[] ids, DateTime from, DateTime until, Double[] vols, Double[][] corrs, double initSpot)
```

#### Parameters

`ids` [String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>
Names of the shares

`from` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
Start date

`until` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
End date

`vols` [Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Volatilities of the shares

`corrs` [Double[][]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Correlations of the shares

`initSpot` [Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
Initial spot value (same for all shares)

#### Returns

[List&lt;ShareValue&gt;](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<br>
The list of market values
