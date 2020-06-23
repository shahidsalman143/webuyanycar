using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WBAC.DeveloperInterview;
using WBAC.DeveloperInterview.Model;
using Moq;
using System.Collections.Generic;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;
using System.Linq;

namespace WBAC.DeveloperInterview.Tests.ValuationServiceTests
{
    [TestClass]
    public class GenerateTests
    {
        [TestMethod]
        public void Generate_ReturnsPopulatedValuation()
        {
            // arrange
            string regPlate = "MA53JRO";
            int mileage = 10000;
            var ageEvaluationCalculator = new AgeEvaluationCalculator(GetAgeEvaluationStrategies());
            var mileageEvaluationCalculator = new MileageEvaluationCalculator(GetMileageStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 10,
                BaseValuation = 40000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            Mock<IVehicleFinder> vehicleFinder = new Mock<IVehicleFinder>();
            vehicleFinder.Setup(x => x.FindByRegPlate(regPlate)).Returns(vehicle);

            IValuationEngine valuationService = new ValuationEngine(vehicleFinder.Object, 
                                                                    ageEvaluationCalculator,
                                                                    mileageEvaluationCalculator);

            // act
            var result = valuationService.Generate(regPlate, mileage);

            // assert
            Assert.IsInstanceOfType(result, typeof(Valuation));

            Assert.AreEqual(mileage, result.Mileage);
            Assert.AreEqual(regPlate, result.RegPlate);
            Assert.IsNotNull(result.AgeInYears);
            Assert.IsNotNull(result.PriceOffered);
        }

        [TestMethod]
        public void Generate_ReducesValuation_BasedOnMileage()
        {
            // arrange
            string regPlate = "MA53JRO";
            int mileage = 10000;
            decimal expectedValue = 17952.11M;
            var ageEvaluationCalculator = new AgeEvaluationCalculator(GetAgeEvaluationStrategies());
            var mileageEvaluationCalculator = new MileageEvaluationCalculator(GetMileageStrategies());

            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 10,
                BaseValuation = 30000,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };

            Mock<IVehicleFinder> vehicleFinder = new Mock<IVehicleFinder>();
            vehicleFinder.Setup(x => x.FindByRegPlate(regPlate)).Returns(vehicle);

            IValuationEngine valuationService = new ValuationEngine(vehicleFinder.Object,
                                                                    ageEvaluationCalculator,
                                                                    mileageEvaluationCalculator);

            // act
            var result = valuationService.Generate(regPlate, mileage);

            // assert
            Assert.AreEqual(expectedValue, result.PriceOffered);
        }

        [TestMethod]
        public void When_Generate_Cannot_Find_The_Vehicle_Should_Return_UnIdentifiedVehicle()
        {
            // arrange
            string regPlate = "MA53JRO";
            int mileage = 10000;
            var ageEvaluationCalculator = new AgeEvaluationCalculator(GetAgeEvaluationStrategies());
            var mileageEvaluationCalculator = new MileageEvaluationCalculator(GetMileageStrategies());
            Vehicle vehicle = null;
            var expectedValue = ErrorTypes.UnIdentifiedVehicle;

            Mock<IVehicleFinder> vehicleFinder = new Mock<IVehicleFinder>();
            vehicleFinder.Setup(x => x.FindByRegPlate(regPlate)).Returns(vehicle);

            IValuationEngine valuationService = new ValuationEngine(vehicleFinder.Object,
                                                                    ageEvaluationCalculator,
                                                                    mileageEvaluationCalculator);

            // act
            var result = valuationService.Generate(regPlate, mileage);

            // assert
            Assert.AreEqual(expectedValue, result.Errors.First());
        }

        [TestMethod]
        public void When_Generate_Called_With_NullBaseValue_ForVehicle_Should_Return_UnableToEvaluate()
        {
            // arrange
            string regPlate = "MA53JRO";
            int mileage = 10000;
            var ageEvaluationCalculator = new AgeEvaluationCalculator(GetAgeEvaluationStrategies());
            var mileageEvaluationCalculator = new MileageEvaluationCalculator(GetMileageStrategies());
            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 10,
                BaseValuation = null,
            };
            
            var expectedValue = ErrorTypes.UnableToEvaluate;

            Mock<IVehicleFinder> vehicleFinder = new Mock<IVehicleFinder>();
            vehicleFinder.Setup(x => x.FindByRegPlate(regPlate)).Returns(vehicle);

            IValuationEngine valuationService = new ValuationEngine(vehicleFinder.Object,
                                                                    ageEvaluationCalculator,
                                                                    mileageEvaluationCalculator);

            // act
            var result = valuationService.Generate(regPlate, mileage);

            // assert
            Assert.AreEqual(expectedValue, result.Errors.First());
        }

        [TestMethod]
        public void When_Generate_Called_And_Evaluation_ForVehicle_Becomes_Negative_Then_It_Should_Return_MinimumEvaluationValue()
        {
            // arrange
            string regPlate = "MA53JRO";
            int mileage = 10000;
            var ageEvaluationCalculator = new AgeEvaluationCalculator(GetAgeEvaluationStrategies());
            var mileageEvaluationCalculator = new MileageEvaluationCalculator(GetMileageStrategies());
            Vehicle vehicle = new Vehicle()
            {
                AgeInYears = 30,
                BaseValuation = 10,
                Derivative = "ZETEC",
                Manufacturer = "FORD",
                Model = "FIESTA",
                RegPlate = "MA53JRO"
            };
            
            var expectedValue = 250.0m;

            Mock<IVehicleFinder> vehicleFinder = new Mock<IVehicleFinder>();
            vehicleFinder.Setup(x => x.FindByRegPlate(regPlate)).Returns(vehicle);

            IValuationEngine valuationService = new ValuationEngine(vehicleFinder.Object,
                                                                    ageEvaluationCalculator,
                                                                    mileageEvaluationCalculator);

            // act
            var result = valuationService.Generate(regPlate, mileage);

            // assert
            Assert.AreEqual(expectedValue, result.PriceOffered);
        }


        private IList<IAgeStrategy> GetAgeEvaluationStrategies()
        {
            return new List<IAgeStrategy>()
            {
                new ZeroYearStrategy(),
                new OlderThanAYearStrategy()
            };
        }

        private IList<IMileageStrategy> GetMileageStrategies()
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
