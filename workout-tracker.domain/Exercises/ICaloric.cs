namespace workout_tracker.domain
{
    public interface ICaloric
    {
        decimal Calories { get; }
        decimal CalculateCalories(decimal weight);
    }

    /// <summary>
    /// https://www.runnersworld.com/nutrition-weight-loss/a20825897/how-many-calories-are-you-really-burning-0/
    /// </summary>
    public class RunningCalorieCalculator : ICaloric
    {
        public decimal Calories => throw new System.NotImplementedException();

        public decimal CalculateCalories(decimal weight)
        {
            return 0.75m * weight;
        }
    }
    public class WalkingCalorieCalculator : ICaloric

    {
        public decimal Calories => throw new System.NotImplementedException();

        public decimal CalculateCalories(decimal weight)
        {
            return 0.53m * weight;
        }
    }
}
