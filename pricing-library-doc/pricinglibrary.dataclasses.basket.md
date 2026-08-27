# Basket

Namespace: PricingLibrary.DataClasses

Class representing a basket option.

```csharp
public class Basket
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [Basket](./pricinglibrary.dataclasses.basket.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Strike**

The option strike.

```csharp
public double Strike { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Maturity**

The option maturity.

```csharp
public DateTime Maturity { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **UnderlyingShareIds**

The string identifiers of the underlying shares for the option.

```csharp
public String[] UnderlyingShareIds { get; set; }
```

#### Property Value

[String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **Weights**

The weight of each underlying in the basket payoff. `Weights[i]` applies to the share identified by `UnderlyingShareIds[i]`.

```csharp
public Double[] Weights { get; set; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

## Constructors

### **Basket()**

```csharp
public Basket()
```
