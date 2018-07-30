using System.Collections.Generic;

namespace workout_tracker.domain
{
    public interface ITrainer
    {
        ICollection<Workout> CoachingSessions { get; set; }
        ICollection<ITrainee> Trainees { get; set; }
    }
}
