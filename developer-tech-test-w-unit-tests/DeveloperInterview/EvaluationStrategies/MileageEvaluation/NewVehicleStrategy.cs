using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public class NewVehicleStrategy : IMileageStrategy
    {
        private const int NEW_CARS_AGE_LIMIT = 3;
        private const decimal REDUCTION_PERCENTAGE_PER_THOUSAND_MILES = 0.5M;

        public decimal CalculatePriceReductionByMileage(int mileage)
        {
            return (decimal)mileage  * REDUCTION_PERCENTAGE_PER_THOUSAND_MILES / 100 ;
        }

        public bool IsApplicable(int age)
        {
            return age <= NEW_CARS_AGE_LIMIT;
        }
    }
}
