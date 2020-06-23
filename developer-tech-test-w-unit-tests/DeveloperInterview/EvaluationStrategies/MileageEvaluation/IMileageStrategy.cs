using WBAC.DeveloperInterview.Model;

namespace WBAC.DeveloperInterview.EvaluationStrategies.MileageEvaluation
{
    public interface IMileageStrategy
    {
        bool IsApplicable(int age);
        decimal CalculatePriceReductionByMileage(int mileage);
    }
}
