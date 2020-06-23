using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public class OlderAgeStrategy : IMileageStrategy
    {
        private const int DECENT_VEHICLE_MINIMUM_AGE_LIMIT = 10;
        private const decimal REDUCTION_PERCENTAGE_PER_THOUSAND_MILES = 0.1M;

        public decimal CalculatePriceReductionByMileage(int mileage)
        {
            return (decimal)mileage * REDUCTION_PERCENTAGE_PER_THOUSAND_MILES / 100;
        }

        public bool IsApplicable(int age)
        {
            return age >= DECENT_VEHICLE_MINIMUM_AGE_LIMIT;
        }
    }
}
