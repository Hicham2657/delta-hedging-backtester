# RebalancingOracleType

Namespace: PricingLibrary.RebalancingOracleDescriptions

Enum of the possible rebalancing types

```csharp
public enum RebalancingOracleType
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ValueType](https://docs.microsoft.com/en-us/dotnet/api/system.valuetype) → [Enum](https://docs.microsoft.com/en-us/dotnet/api/system.enum) → [RebalancingOracleType](./pricinglibrary.rebalancingoracledescriptions.rebalancingoracletype.md)<br>
Implements [IComparable](https://docs.microsoft.com/en-us/dotnet/api/system.icomparable), [ISpanFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.ispanformattable), [IFormattable](https://docs.microsoft.com/en-us/dotnet/api/system.iformattable), [IConvertible](https://docs.microsoft.com/en-us/dotnet/api/system.iconvertible)

## Fields

| Name | Value | Description |
| --- | --: | --- |
| Regular | 0 | Regular rebalancing, for a given period |
| Spot | 1 | Rebalancing when the spots diverge too much from those at the last rebalancing |
