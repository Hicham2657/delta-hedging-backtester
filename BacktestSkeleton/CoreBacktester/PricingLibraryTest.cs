using PricingLibrary.TimeHandler;

namespace CoreBacktester
{
    public static class PricingLibraryTest
    {
        public static double TestMathDateConverter()
        {
            var date1 = new DateTime(2009, 4 , 14);
            var date2 = new DateTime(2013, 3, 28);
            return MathDateConverter.ConvertToMathDistance(date1, date2);
        }
    }
}
