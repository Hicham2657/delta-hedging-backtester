# ShareValue

Namespace: PricingLibrary.MarketDataFeed

Class that stores the value of the share at a given date.

```csharp
public class ShareValue
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [ShareValue](./pricinglibrary.marketdatafeed.sharevalue.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **Id**

Property containing the id of the share.

```csharp
public string Id { get; set; }
```

#### Property Value

[String](https://docs.microsoft.com/en-us/dotnet/api/system.string)<br>

### **DateOfPrice**

Property the date at which this share price was observed.

```csharp
public DateTime DateOfPrice { get; set; }
```

#### Property Value

[DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>

### **Value**

Property containing the value of the share.

```csharp
public double Value { get; set; }
```

#### Property Value

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>

## Constructors

### **ShareValue()**

```csharp
public ShareValue()
```
