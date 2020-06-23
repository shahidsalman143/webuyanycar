using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public class MileageEvaluationCalculator : IMileageEvaluationCalculator
    {
        private readonly IList<IMileageStrategy> _mileageEvaulationStrategies;

        public MileageEvaluationCalculator(IList<IMileageStrategy> mileageEvaulationStrategies)
        {
            _mileageEvaulationStrategies = mileageEvaulationStrategies;
        }


        public decimal CalculatePriceReductionByMileage(Vehicle vehicle, int mileage)
        {
            return _mileageEvaulationStrategies.FirstOrDefault(x => x.IsApplicable(vehicle.AgeInYears))
                                            .CalculatePriceReductionByMileage(mileage);
        }
    }
}
