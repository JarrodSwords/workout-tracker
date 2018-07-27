using System;

namespace workout_tracker.domain
{
    public class Distance
    {
        public decimal Meters { get; }

        public Distance(decimal meters)
        {
            Validate(meters);
            Meters = meters;
        }

        private void Validate(decimal meters)
        {
            if (meters < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
