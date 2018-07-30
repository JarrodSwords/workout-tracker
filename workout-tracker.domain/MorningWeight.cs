using System;

namespace workout_tracker.domain
{
    /// <summary>
    /// A Trainee's "official-enough" weight pre-workout
    /// </summary>
    public class MorningWeight
    {
        public DateTime Date { get; set; }
        public Weight Weight { get; set; }
    }
}
