using System;

namespace workout_tracker.domain {
    public class Time
    {
        public decimal Seconds { get; }

        public Time(decimal seconds)
        {
            Validate(seconds);
            Seconds = seconds;
        }

        private void Validate(decimal seconds)
        {
            if (seconds < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
