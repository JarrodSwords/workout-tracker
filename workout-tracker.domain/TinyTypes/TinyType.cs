namespace workout_tracker.domain
{
    public class TinyType<T> where T : struct
    {
        private readonly T _value;

        public T Value { get => _value; }

        public TinyType(T value)
        {
            _value = value;
        }
    }
}
