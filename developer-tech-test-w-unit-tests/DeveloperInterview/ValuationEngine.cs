using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation;
using WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview
{
    public class ValuationEngine : IValuationEngine
    {
        private const decimal MINIMUM_EVALUATION_VALUE = 250.0M;
        private readonly IVehicleFinder _vehicleFinder;
        private readonly IAgeEvaluationCalculator _ageEvaluationCalculator;
        private readonly IMileageEvaluationCalculator _mileageEvaluationCalculator;

        public ValuationEngine(IVehicleFinder vehicleFinder,
                               IAgeEvaluationCalculator ageEvaluationCalculator,
                               IMileageEvaluationCalculator mileageEvaluationCalculator)
        {
            _vehicleFinder = vehicleFinder;
            _ageEvaluationCalculator = ageEvaluationCalculator;
            _mileageEvaluationCalculator = mileageEvaluationCalculator;
        }

        public Valuation Generate(string regPlate, int mileage)
        {
            var vehicle = _vehicleFinder.FindByRegPlate(regPlate);
            if (vehicle == null)
                return new Valuation() { Errors = new List<ErrorTypes>() { ErrorTypes.UnIdentifiedVehicle} };
            if (!vehicle.BaseValuation.HasValue)
                return new Valuation() { Errors = new List<ErrorTypes>() { ErrorTypes.UnableToEvaluate } };

            decimal priceOffered = vehicle.BaseValuation.Value;
            CalculatePriceOffered(mileage, vehicle, ref priceOffered);
            
            return new Valuation()
            {
                Mileage = mileage,
                RegPlate = regPlate,
                AgeInYears = vehicle.AgeInYears,
                PriceOffered = priceOffered < 0 ? MINIMUM_EVALUATION_VALUE : 
                                                  decimal.Round(priceOffered, 2, MidpointRounding.AwayFromZero)
            };
        }

        private void CalculatePriceOffered(int mileage, Vehicle vehicle, ref decimal priceOffered) 
        {
            priceOffered -= _ageEvaluationCalculator.CalculatePriceReductionByAge(vehicle);

            priceOffered -= _mileageEvaluationCalculator.CalculatePriceReductionByMileage(vehicle, mileage);
        }


    }
}
