# OutputData

Namespace: PricingLibrary.DataClasses

Container class for output data.

```csharp
public class OutputData
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [OutputData](./pricinglibrary.dataclasses.outputdata.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Date**

The date at which the output data was generated

```csharp
public DateTime Date { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **Value**

The net value of the portfolio at the given date

```csharp
public double Value { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Deltas**

The deltas output by the pricer at the given date

```csharp
public Double[] Deltas { get; set; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **DeltasStdDev**

The standard deviation of the deltas computed by the pricer at the given date

```csharp
public Double[] DeltasStdDev { get; set; }
```

#### Property Value

[Double[]](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **Price**

The price output by the pricer at the given date

```csharp
public double Price { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **PriceStdDev**

The standard deviation of the price computed by the pricer at the given date

```csharp
public double PriceStdDev { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

### **TransactionCosts**

The transaction costs at each rebalancing. They can be set to zero for the project.

```csharp
public double TransactionCosts { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

## Constructors

### **OutputData()**

```csharp
public OutputData()
```
