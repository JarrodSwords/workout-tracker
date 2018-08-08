using System;

namespace workout_tracker.domain
{
    public class Exercise : Entity
    {
        public string Name { get; protected set; }
        public Repetitions Repetitions { get; }
        public Sets Sets { get; }

        protected Exercise(string name, string defaultName, Repetitions repetitions = null, Sets sets = null)
        {
            Name = ValidateName(name, defaultName);
            Repetitions = repetitions ?? new Repetitions(1);
            Sets = sets ?? new Sets(1);
        }

        protected string ValidateName(string name, string defaultName)
        {
            return String.IsNullOrWhiteSpace(name) ? defaultName : name;
        }
    }
}
