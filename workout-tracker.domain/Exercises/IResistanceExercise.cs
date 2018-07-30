namespace workout_tracker.domain
{
    public interface IResistanceExercise
    {
        bool IsToFailure { get; }
        Resistance Resistance { get; }
    }
}
