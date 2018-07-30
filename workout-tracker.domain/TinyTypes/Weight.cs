namespace workout_tracker.domain
{
    public class Weight : TinyType<decimal>
    {
        public Weight(decimal value) : base(value)
        {
        }
    }
}
