# RebalancingOracleDescriptionConverter

Namespace: PricingLibrary.RebalancingOracleDescriptions

Converter to be used to deserialize a rebalancing oracle description, by providing it to the set of Converters in the set of options of .

```csharp
public class RebalancingOracleDescriptionConverter : System.Text.Json.Serialization.JsonConverter`1[[PricingLibrary.RebalancingOracleDescriptions.IRebalancingOracleDescription, PricingLibrary, Version=2.0.9.0, Culture=neutral, PublicKeyToken=null]]
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → JsonConverter → JsonConverter&lt;IRebalancingOracleDescription&gt; → [RebalancingOracleDescriptionConverter](./pricinglibrary.rebalancingoracledescriptions.rebalancingoracledescriptionconverter.md)<br>
Attributes [NullableContextAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullablecontextattribute), [NullableAttribute](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.nullableattribute)

## Properties

### **HandleNull**

```csharp
public bool HandleNull { get; }
```

#### Property Value

[Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)<br>

### **Type**

```csharp
public Type Type { get; }
```

#### Property Value

[Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

## Constructors

### **RebalancingOracleDescriptionConverter()**

```csharp
public RebalancingOracleDescriptionConverter()
```

## Methods

### **Read(Utf8JsonReader&, Type, JsonSerializerOptions)**

Method used by the json deserializer

```csharp
public IRebalancingOracleDescription Read(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options)
```

#### Parameters

`reader` Utf8JsonReader&<br>

`typeToConvert` [Type](https://docs.microsoft.com/en-us/dotnet/api/system.type)<br>

`options` JsonSerializerOptions<br>

#### Returns

[IRebalancingOracleDescription](./pricinglibrary.rebalancingoracledescriptions.irebalancingoracledescription.md)<br>
A rebalancing oracle description

#### Exceptions

[ArgumentNullException](https://docs.microsoft.com/en-us/dotnet/api/system.argumentnullexception)<br>

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>

### **Write(Utf8JsonWriter, IRebalancingOracleDescription, JsonSerializerOptions)**

Method used by the json serializer

```csharp
public void Write(Utf8JsonWriter writer, IRebalancingOracleDescription value, JsonSerializerOptions options)
```

#### Parameters

`writer` Utf8JsonWriter<br>
The writer used in the serialization

`value` [IRebalancingOracleDescription](./pricinglibrary.rebalancingoracledescriptions.irebalancingoracledescription.md)<br>
The description to serialize

`options` JsonSerializerOptions<br>
The Json serializer options

#### Exceptions

[InvalidOperationException](https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception)<br>
