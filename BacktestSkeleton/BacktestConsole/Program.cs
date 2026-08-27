using CoreBacktester;

Console.WriteLine("Testing that the PricingLibrary Nuget package is correctly accessed");
var distance = PricingLibraryTest.TestMathDateConverter();
Console.WriteLine($"Read value {distance}");
Console.ReadKey();