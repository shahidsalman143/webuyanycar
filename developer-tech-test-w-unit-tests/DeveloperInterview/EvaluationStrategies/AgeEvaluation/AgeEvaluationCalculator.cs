using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation
{
    public class AgeEvaluationCalculator : IAgeEvaluationCalculator
    {
        private readonly IList<IAgeStrategy> _ageEvaulationStrategies;

        public AgeEvaluationCalculator(IList<IAgeStrategy> ageEvaulationStrategies) 
        {
            _ageEvaulationStrategies = ageEvaulationStrategies;
        }

        public decimal CalculatePriceReductionByAge(Vehicle vehicle)
        {
            return _ageEvaulationStrategies.FirstOrDefault(x => x.IsApplicable(vehicle.AgeInYears))
                                           .CalculatePriceReductionByAge(vehicle);
        }
    }
}
