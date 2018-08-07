using System;
using System.Collections.Generic;
using System.Linq;

namespace workout_tracker.domain
{
    public class CompositeExercise : Exercise, ICaloric
    {
        private ICollection<Exercise> _exercises = new List<Exercise>();

        public ICollection<Exercise> Exercises { get => _exercises; }

        public decimal Calories => throw new NotImplementedException();

        public CompositeExercise Add(Exercise exercise)
        {
            _exercises.Add(exercise);
            return this;
        }

        public decimal CalculateCalories(decimal weight)
        {
            var calories = 0m;

            foreach(var exercise in Exercises.OfType<ICaloric>())
                calories += exercise.CalculateCalories(weight);

            return calories;
        }

        public sealed class CompositeExerciseBuilder
        {
            private string _name;
            private Repetitions _repetitions;
            private Sets _sets;

            public CompositeExerciseBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public CompositeExerciseBuilder WithRepetitions(Repetitions repetitions)
            {
                _repetitions = repetitions;
                return this;
            }

            public CompositeExerciseBuilder WithSets(Sets sets)
            {
                _sets = sets;
                return this;
            }

            public CompositeExercise Build()
            {
                return new CompositeExercise();
            }
        }
    }
}
