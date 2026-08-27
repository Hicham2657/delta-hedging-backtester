# RiskFreeRateProvider

Namespace: PricingLibrary.MarketDataFeed

Provider for operations involving the risk-free rate.

```csharp
public static class RiskFreeRateProvider
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [RiskFreeRateProvider](./pricinglibrary.marketdatafeed.riskfreerateprovider.md)

## Methods

### **GetRiskFreeRateAccruedValue(DateTime, DateTime)**

Method that returns the value of 1 unit of currency accrued over a given time period.

```csharp
public static double GetRiskFreeRateAccruedValue(DateTime from, DateTime until)
```

#### Parameters

`from` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
Start date

`until` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
End date

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The accrued value of 1 unit of currency.
