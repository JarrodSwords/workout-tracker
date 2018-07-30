using System;

namespace workout_tracker.domain
{
    public class Resistance : TinyType<decimal>
    {
        public Resistance(decimal value) : base(value)
        {
            Validate(value);
        }

        private void Validate(decimal resistance)
        {
            if (resistance < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
