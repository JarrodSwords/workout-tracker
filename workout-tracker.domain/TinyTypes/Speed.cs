using System;

namespace workout_tracker.domain {
    public class Speed
    {
        public decimal MetersPerSecond { get; }

        public Speed(decimal metersPerSecond)
        {
            Validate(metersPerSecond);
            MetersPerSecond = metersPerSecond;
        }

        private void Validate(decimal metersPerSecond)
        {
            if (metersPerSecond < 0)
                throw new ArgumentOutOfRangeException();
        }
    }
}
