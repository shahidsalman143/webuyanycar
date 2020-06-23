using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public class DecentAgeStrategy : IMileageStrategy
    {
        private const int DECENT_VEHICLE_MINIMUM_AGE_LIMIT = 4;
        private const int DECENT_VEHICLE_MAXIMUM_AGE_LIMIT = 9;
        private const decimal REDUCTION_PERCENTAGE_PER_THOUSAND_MILES = 0.3M;

        public decimal CalculatePriceReductionByMileage(int mileage)
        {
            return (decimal)mileage * REDUCTION_PERCENTAGE_PER_THOUSAND_MILES / 100;
        }

        public bool IsApplicable(int age)
        {
            return age >= DECENT_VEHICLE_MINIMUM_AGE_LIMIT && age <= DECENT_VEHICLE_MAXIMUM_AGE_LIMIT;
        }
    }
}
