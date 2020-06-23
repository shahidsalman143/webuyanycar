using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.MileageEvaluation
{
    [TestClass]
    public class OldVehicleStrategyTests
    {

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 50.0m;
            var newVehicleStrategy = new OlderAgeStrategy();
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
            var decentVehicleStrategy = new OlderAgeStrategy();
            var mileage = 0;

            // act
            var result = decentVehicleStrategy.CalculatePriceReductionByMileage(mileage);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_OlderVehicles_Then_Result_ShouldBe_True()
        {
            // arrange
            var zeroYearsStatery = new OlderAgeStrategy();
            var vehicaleAge = 11;
            var expected = true;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_NewOrRelativelyNewVehicles_Then_Result_ShouldBe_False()
        {
            // arrange
            var zeroYearsStatery = new OlderAgeStrategy();
            var vehicaleAge = 2;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

       
    }
}
