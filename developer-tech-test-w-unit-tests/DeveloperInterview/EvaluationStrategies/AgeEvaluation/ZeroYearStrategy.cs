using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation
{
    public class ZeroYearStrategy : IAgeStrategy
    {
        public decimal CalculatePriceReductionByAge(Vehicle vehicle)
        {
            return vehicle.BaseValuation.HasValue ? vehicle.BaseValuation.Value * 0.2m : 0;
        }

        public bool IsApplicable(int age)
        {
            return age == 0 ;
        }
    }
}
