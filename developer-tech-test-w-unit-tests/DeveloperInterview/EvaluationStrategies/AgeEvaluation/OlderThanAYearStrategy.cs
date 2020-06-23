using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation
{
    public class OlderThanAYearStrategy : IAgeStrategy
    {
        private const decimal multiplier = 0.05m;

        public decimal CalculatePriceReductionByAge(Vehicle vehicle)
        {
            var result = 0m;
            // just assuming to return 0 (unit test to verify), better approach would be have a guard clause to throw an exception
            // to avoid garbage in/ garbage out
            if (!vehicle.BaseValuation.HasValue)   
                return result;

            var baseValue = vehicle.BaseValuation.Value;
            for (int index = 1; index <= vehicle.AgeInYears; index++) 
            {
                result += baseValue * multiplier;
                baseValue = (vehicle.BaseValuation.Value - result);
            }
            return decimal.Round(result, 2, MidpointRounding.AwayFromZero);
        }

        
        public bool IsApplicable(int age)
        {
            return age > 0;
        }
    }
}
