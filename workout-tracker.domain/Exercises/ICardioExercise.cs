namespace workout_tracker.domain
{
    public interface ICardioExercise
    {
        Distance Distance { get; }
        Speed Speed { get; }
        Time Time { get; }
    }
}
