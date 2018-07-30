using System;

namespace workout_tracker.domain
{
    public class Sets : TinyType<decimal>
    {
        public Sets(decimal value) : base(value)
        {
            Validate(value);
        }

        private void Validate(decimal sets)
        {
            if (sets < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
