# BasketTestParameters

Namespace: PricingLibrary.DataClasses

Class containing the necessary information to run a test, given a collection of market data.

```csharp
public class BasketTestParameters
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [BasketTestParameters](./pricinglibrary.dataclasses.baskettestparameters.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **PricingParams**

The parameters to be used by the pricer

```csharp
public BasketPricingParameters PricingParams { get; set; }
```

#### Property Value

[BasketPricingParameters](./pricinglibrary.dataclasses.basketpricingparameters.md)<br>

### **BasketOption**

The description of the basket option under consideration

```csharp
public Basket BasketOption { get; set; }
```

#### Property Value

[Basket](./pricinglibrary.dataclasses.basket.md)<br>

### **RebalancingOracleDescription**

Information about the way the portfolio will be rebalanced

```csharp
public IRebalancingOracleDescription RebalancingOracleDescription { get; set; }
```

#### Property Value

[IRebalancingOracleDescription](./pricinglibrary.rebalancingoracledescriptions.irebalancingoracledescription.md)<br>

### **TransactionRate**

The transaction rate to be used in the test. Handling transaction rates is optionnal in this class, the rate can be set to 0.

```csharp
public double TransactionRate { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

## Constructors

### **BasketTestParameters()**

```csharp
public BasketTestParameters()
```
