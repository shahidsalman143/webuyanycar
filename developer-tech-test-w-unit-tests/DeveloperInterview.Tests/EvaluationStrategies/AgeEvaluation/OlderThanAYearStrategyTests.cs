using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;


namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.AgeEvaluation
{
    [TestClass]
    public class OlderThanAYearStrategyTests
    {

        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_For_3YearOldCar_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 3137.75m;
            var olderThanYearStatery = new OlderThanAYearStrategy();

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 3,
                BaseValuation = 22000,
            };

            // act
            var result = olderThanYearStatery.CalculatePriceReductionByAge(vehicle);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_For_4YearOldCar_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 2782.41m;
            var olderThanYearStatery = new OlderThanAYearStrategy();

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 4,
                BaseValuation = 15000,
            };

            // act
            var result = olderThanYearStatery.CalculatePriceReductionByAge(vehicle);

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
        public void When_IsApplicable_Called_For_OlderCars_Then_Result_ShouldBe_True()
        {
            // arrange
            var zeroYearsStatery = new OlderThanAYearStrategy();
            var vehicaleAge = 1;
            var expected = true;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_NewCars_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var zeroYearsStatery = new OlderThanAYearStrategy();
            var vehicaleAge = 0;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
