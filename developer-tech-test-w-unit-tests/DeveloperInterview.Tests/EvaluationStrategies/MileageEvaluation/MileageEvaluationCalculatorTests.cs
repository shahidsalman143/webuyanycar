using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using System.Collections.Generic;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.MileageEvaluation
{
    [TestClass]
    public class MileageEvaluationCalculatorTests
    {

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_For_NewVehicle_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 250.0m;
            var mileage = 50000;
            var strategy = new MileageEvaluationCalculator(GetStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 0,
                BaseValuation = 50000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            // act
            var result = strategy.CalculatePriceReductionByMileage(vehicle, mileage);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_For_DecentVehicle_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 150.0m;
            var mileage = 50000;
            var strategy = new MileageEvaluationCalculator(GetStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 4,
                BaseValuation = 50000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            // act
            var result = strategy.CalculatePriceReductionByMileage(vehicle, mileage);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByMileage_Called_For_OldVehicle_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 50.0m;
            var mileage = 50000;
            var strategy = new MileageEvaluationCalculator(GetStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 10,
                BaseValuation = 50000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            // act
            var result = strategy.CalculatePriceReductionByMileage(vehicle, mileage);

            // assert
            Assert.AreEqual(expected, result);
        }



        private IList<IMileageStrategy> GetStrategies()
        {
            return new List<IMileageStrategy>()
            {
                new NewVehicleStrategy(),
                new DecentAgeStrategy(),
                new OlderAgeStrategy()
            };
        }
    }
}
