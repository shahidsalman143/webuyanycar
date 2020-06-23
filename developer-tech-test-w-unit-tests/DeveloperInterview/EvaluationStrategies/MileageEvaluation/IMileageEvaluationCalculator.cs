using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public interface IMileageEvaluationCalculator
    {
        decimal CalculatePriceReductionByMileage(Vehicle vehicle, int mileage);
    }
}
