# MathDateConverter

Namespace: PricingLibrary.TimeHandler

Converts a pair of calendar dates to a mathematical time distance expressed in years, using the business-day count convention.

```csharp
public static class MathDateConverter
```

Inheritance [Object](https://docs.microsoft.com/en-us/dotnet/api/system.object) → [MathDateConverter](./pricinglibrary.timehandler.mathdateconverter.md)

## Methods

### **ConvertToMathDistance(DateTime, DateTime)**

Converter method

```csharp
public static double ConvertToMathDistance(DateTime from, DateTime until)
```

#### Parameters

`from` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
Start date

`until` [DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)<br>
End date

#### Returns

[Double](https://docs.microsoft.com/en-us/dotnet/api/system.double)<br>
The time distance converted to a double
