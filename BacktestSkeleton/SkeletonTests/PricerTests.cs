using PricingLibrary.DataClasses;
using PricingLibrary.Computations;
using PricingLibrary.RebalancingOracleDescriptions;

namespace SkeletonTests
{
    public class PricerTests
    {
        Pricer _pricer;

        [SetUp]
        public void Setup()
        {
            var basket = new Basket
            {
                Strike = 10,
                Maturity = new DateTime(2023, 12, 12),
                UnderlyingShareIds = ["share_1"],
                Weights = [1]
            };
            var testparams = new BasketTestParameters
            {
                BasketOption = basket,
                PricingParams = new BasketPricingParameters
                {
                    Correlations = [[1]],
                    Volatilities = [0.2]
                },
                RebalancingOracleDescription = new RegularOracleDescription
                {
                    Period = 1
                }
            };
            _pricer = new Pricer(testparams);
        }

        [Test]
        public void Price_ReturnsPositivePrice_WhenAtTheMoney()
        {
            var results = _pricer.Price(new DateTime(2023, 6, 22), [10]);
            Assert.That(results.Price, Is.GreaterThan(0.0));
        }

        [Test]
        public void Price_DeltaBetween01_Always()
        {
            var results = _pricer.Price(new DateTime(2023, 6, 22), [10]);
            Assert.That(results.Deltas[0], Is.GreaterThanOrEqualTo(0.0).And.LessThanOrEqualTo(1.0));
        }

        [Test]
        public void Price_IncreasingFunction_Always()
        {
            var result_inf = _pricer.Price(new DateTime(2023, 6, 22), [9]);
            var result_sup = _pricer.Price(new DateTime(2023, 6, 22), [10]);
            Assert.That(result_sup.Price, Is.GreaterThan(result_inf.Price));
        }
    }
}