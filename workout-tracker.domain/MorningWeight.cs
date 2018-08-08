using System;
using UnitsNet;

namespace workout_tracker.domain
{
    /// <summary>
    /// A Trainee's "official-enough" weight pre-workout
    /// </summary>
    public class MorningMass
    {
        public DateTime Date { get; set; }
        public Mass Mass { get; set; }
    }
}
