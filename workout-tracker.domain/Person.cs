using System;
using System.Collections.Generic;

namespace workout_tracker.domain
{
    public class Person : Entity, ITrainer, ITrainee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; }
        public ICollection<MorningWeight> Weights { get; set; }
        public ICollection<Workout> CoachingSessions { get; set; }
        public ICollection<ITrainee> Trainees { get; set; }
        public ICollection<ITrainer> Trainers { get; set; }
        public ICollection<Workout> Workouts { get; set; }

        public Person(string name, string surname, DateTime birthdate)
        {
            
        }
    }
}
