namespace workout_tracker.domain
{
    public interface ICardio
    {
        Distance Distance { get; }
        Speed Speed { get; }
        Time Time { get; }
    }
}
