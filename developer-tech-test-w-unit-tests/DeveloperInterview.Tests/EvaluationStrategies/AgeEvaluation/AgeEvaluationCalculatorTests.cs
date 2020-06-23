using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview.Model;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using System.Collections.Generic;

namespace WBAC.DeveloperInterview.Tests.EvaluationStrategies.AgeEvaluation
{
    [TestClass]
    public class AgeEvaluationCalculatorTests
    {
        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_For_NewCar_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 8000.0m;
            var strategy = new AgeEvaluationCalculator(GetStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 0,
                BaseValuation = 40000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            // act
            var result = strategy.CalculatePriceReductionByAge(vehicle);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void When_CalculatePriceReductionByAge_Called_For_10YearsOldCar_Then_Result_ShouldBe_Expected()
        {
            // arrange
            var expected = 16050.52m;
            var strategy = new AgeEvaluationCalculator(GetStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 10,
                BaseValuation = 40000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            // act
            var result = strategy.CalculatePriceReductionByAge(vehicle);

            // assert
            Assert.AreEqual(expected, result);
        }

        private IList<IAgeStrategy> GetStrategies() 
        {
            return new List<IAgeStrategy>()
            {
                new ZeroYearStrategy(),
                new OlderThanAYearStrategy()
            };
        }
    }
}
