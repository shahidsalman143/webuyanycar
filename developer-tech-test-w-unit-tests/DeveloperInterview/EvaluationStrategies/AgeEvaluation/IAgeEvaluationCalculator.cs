using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.AgeEvaluation
{
    public interface IAgeEvaluationCalculator
    {
        decimal CalculatePriceReductionByAge(Vehicle vehicle);
    }
}
