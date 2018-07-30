using System;

namespace workout_tracker.domain
{
    public class Workout : Entity
    {
        public Exercise Exercise { get; set; }
        public DateTime StartTime { get; set; }
        public ITrainee Trainee { get; set; }
        public ITrainer Trainer { get; set; }
        public WorkoutStatus WorkoutStatus { get; set; }
    }
}
