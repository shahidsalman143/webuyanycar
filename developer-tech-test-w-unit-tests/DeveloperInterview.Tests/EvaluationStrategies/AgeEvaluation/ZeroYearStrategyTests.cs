using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.AgeEvaluation
{
    [TestClass]
    public class ZeroYearStrategyTests
    {
        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_To_Calculate_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 2620.0m;
            var zeroYearsStatery = new ZeroYearStrategy();

             Vehicle vehicle = new Vehicle()
             {
                AgeInYears = 0,
                BaseValuation = 13100,
             };

           // act
            var result = zeroYearsStatery.CalculatePriceReductionByAge(vehicle);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_With_NullBasePrice_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 0m;
            var zeroYearsStatery = new ZeroYearStrategy();

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 0,
                BaseValuation = null
            };

            // act
            var result = zeroYearsStatery.CalculatePriceReductionByAge(vehicle);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_OlderCars_Then_Result_ShouldBe_False()
        {
            // arrange
            var zeroYearsStatery = new ZeroYearStrategy();
            var vehicaleAge = 1;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_NewCars_Then_Result_ShouldBe_True()
        {
            // arrange
            var zeroYearsStatery = new ZeroYearStrategy();
            var vehicaleAge = 0;
            var expected = true;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
