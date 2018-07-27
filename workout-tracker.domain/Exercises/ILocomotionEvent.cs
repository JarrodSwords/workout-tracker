namespace workout_tracker.domain
{
    public interface ILocomotionEvent
    {
        Distance Distance { get; }
        Speed Speed { get; }
        Time Time { get; }
    }
}
