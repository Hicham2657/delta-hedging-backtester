# Pricer

Namespace: PricingLibrary.Computations

Class in charge of computing the price and deltas for the considered derivatives.

```csharp
public class Pricer
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Pricer](./pricinglibrary.computations.pricer.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **UnderlyingShareIds**

String array used for the mapping between the array returned in the Delta field of [PricingResults](./pricinglibrary.dataclasses.pricingresults.md)
 and a portfolio composition.

```csharp
public String[] UnderlyingShareIds { get; }
```

#### Property Value

[String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

## Constructors

### **Pricer(BasketTestParameters)**

Constructor for the class

```csharp
public Pricer(BasketTestParameters testParams)
```

#### Parameters

`testParams` [BasketTestParameters](./pricinglibrary.dataclasses.baskettestparameters.md)<br>
The input test parameters

## Methods

### **Price(DateTime, Double[])**

Main method of the class, which computes the price and deltas of a basket option.

```csharp
public PricingResults Price(DateTime date, Double[] spots)
```

#### Parameters

`date` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
The date at which the product is to be priced.

`spots` [Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The spots of the underlyings at the current time. WARNING: it is important to make
 sure the spots are in the correct order: `spot[i]` must be the price of `UnderlyingShareIds[i]`.

#### Returns

[PricingResults](./pricinglibrary.dataclasses.pricingresults.md)<br>
The price and deltas computed by the method. The value stored at position i in deltas is related to the value
 stored at position i in `spots`.
