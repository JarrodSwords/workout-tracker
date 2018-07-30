using System;
using System.Collections.Generic;

namespace workout_tracker.domain
{
    public interface ITrainee
    {
        ICollection<ITrainer> Trainers { get; set; }
        ICollection<Workout> Workouts { get; set; }
    }
}
