namespace workout_tracker.domain
{
    public interface IResistance
    {
        bool IsToFailure { get; set; }
        Resistance Resistance { get; set; }
    }
}
