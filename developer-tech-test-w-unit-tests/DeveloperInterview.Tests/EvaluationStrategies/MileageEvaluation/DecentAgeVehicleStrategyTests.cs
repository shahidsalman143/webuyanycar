using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.MileageEvaluation
{
    [TestClass]
    public class DecentAgeVehicleStrategyTests
    {


        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 150.0m;
            var newVehicleStrategy = new DecentAgeStrategy();
            var mileage = 50000;

            // act
            var result = newVehicleStrategy.CalculatePriceReductionByMileage(mileage);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_For_ZeroMileage_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 0m;
            var decentVehicleStrategy = new DecentAgeStrategy();
            var mileage = 0;

            // act
            var result = decentVehicleStrategy.CalculatePriceReductionByMileage(mileage);

            // assert
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void When_IsApplicable_Called_For_OlderVehicles_Then_Result_ShouldBe_False()
        {
            // arrange
            var zeroYearsStatery = new DecentAgeStrategy();
            var vehicaleAge = 11;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_NewVehicles_Then_Result_ShouldBe_False()
        {
            // arrange
            var zeroYearsStatery = new DecentAgeStrategy();
            var vehicaleAge = 2;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_DecentVehicles_Then_Result_ShouldBe_True()
        {
            // arrange
            var zeroYearsStatery = new DecentAgeStrategy();
            var vehicaleAge = 5;
            var expected = true;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
