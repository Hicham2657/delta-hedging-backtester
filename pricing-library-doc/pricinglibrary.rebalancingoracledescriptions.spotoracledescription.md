# SpotOracleDescription

Namespace: PricingLibrary.RebalancingOracleDescriptions

Info for an oracle that should trigger a rebalancing when the absolute return of one of the underlyings
 since the last rebalancing is above a given threshold. A threshold of 0.1 means 10%.

```csharp
public class SpotOracleDescription : IRebalancingOracleDescription
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [SpotOracleDescription](./pricinglibrary.rebalancingoracledescriptions.spotoracledescription.md)<br>
Implements [IRebalancingOracleDescription](./pricinglibrary.rebalancingoracledescriptions.irebalancingoracledescription.md)

## Properties

### **Threshold**

The threshold above which a rebalancing should be triggered.

```csharp
public double Threshold { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Type**

The rebalancing oracle type

```csharp
public RebalancingOracleType Type { get; }
```

#### Property Value

[RebalancingOracleType](./pricinglibrary.rebalancingoracledescriptions.rebalancingoracletype.md)<br>

## Constructors

### **SpotOracleDescription()**

Constructor

```csharp
public SpotOracleDescription()
```
