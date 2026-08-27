# PricingResults

Namespace: PricingLibrary.DataClasses

Data class returned by the main method of the [Pricer](./pricinglibrary.computations.pricer.md) class.

```csharp
public class PricingResults
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [PricingResults](./pricinglibrary.dataclasses.pricingresults.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Price**

Readonly property containing the price of the option.

```csharp
public double Price { get; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Deltas**

Readonly property containing the deltas of the option. 
 Element at position i corresponds to underlying i of the corresponding [Basket](./pricinglibrary.dataclasses.basket.md) object.

```csharp
public Double[] Deltas { get; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **PriceStdDev**

Readonly property containing the price standard deviation (0 in this class because not relevant)

```csharp
public double PriceStdDev { get; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **DeltaStdDev**

Readonly property containing the delta standard deviations (0 in this class because not relevant)

```csharp
public Double[] DeltaStdDev { get; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
