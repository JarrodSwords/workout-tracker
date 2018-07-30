using System;

namespace workout_tracker.domain
{
    public class Repetitions : TinyType<decimal>
    {
        public Repetitions(decimal value) : base(value)
        {
            Validate(value);
        }

        private void Validate(decimal reps)
        {
            if (reps < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
