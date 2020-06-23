using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.MileageEvaluation
{
    [TestClass]
    public class NewVehicleStrategyTests
    {

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 250.0m;
            var newVehicleStrategy = new NewVehicleStrategy();
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
            var newVehicleStrategy = new NewVehicleStrategy();
            var mileage = 0;

            // act
            var result = newVehicleStrategy.CalculatePriceReductionByMileage(mileage);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_OlderVehicles_Then_Result_ShouldBe_False()
        {
            // arrange
            var zeroYearsStatery = new NewVehicleStrategy();
            var vehicaleAge = 4;
            var expected = false;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_IsApplicable_Called_For_NewVehicles_Then_Result_ShouldBe_True()
        {
            // arrange
            var zeroYearsStatery = new NewVehicleStrategy();
            var vehicaleAge = 2;
            var expected = true;

            // act
            var result = zeroYearsStatery.IsApplicable(vehicaleAge);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
