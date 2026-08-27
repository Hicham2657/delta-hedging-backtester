# RegularOracleDescription

Namespace: PricingLibrary.RebalancingOracleDescriptions

Info for an oracle that should trigger a rebalancing periodically

```csharp
public class RegularOracleDescription : IRebalancingOracleDescription
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [RegularOracleDescription](./pricinglibrary.rebalancingoracledescriptions.regularoracledescription.md)<br>
Implements [IRebalancingOracleDescription](./pricinglibrary.rebalancingoracledescriptions.irebalancingoracledescription.md)

## Properties

### **Period**

The number of business days between successive rebalancings. Must be strictly positive.

```csharp
public int Period { get; set; }
```

#### Property Value

[Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32)<br>

### **Type**

The rebalancing oracle type

```csharp
public RebalancingOracleType Type { get; }
```

#### Property Value

[RebalancingOracleType](./pricinglibrary.rebalancingoracledescriptions.rebalancingoracletype.md)<br>

## Constructors

### **RegularOracleDescription()**

Constructor

```csharp
public RegularOracleDescription()
```
