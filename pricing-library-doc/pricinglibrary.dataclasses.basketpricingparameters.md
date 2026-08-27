# BasketPricingParameters

Namespace: PricingLibrary.DataClasses

Class containing the information to price the considered option.

```csharp
public class BasketPricingParameters
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BasketPricingParameters](./pricinglibrary.dataclasses.basketpricingparameters.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Volatilities**

The volatilities of the underlyings. 
 Element i of this array corresponds to underlying i of the corresponding [Basket](./pricinglibrary.dataclasses.basket.md) object.

```csharp
public Double[] Volatilities { get; set; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Correlations**

The correlations between the underlyings.

```csharp
public Double[][] Correlations { get; set; }
```

#### Property Value

[Double[][]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

## Constructors

### **BasketPricingParameters()**

```csharp
public BasketPricingParameters()
```
