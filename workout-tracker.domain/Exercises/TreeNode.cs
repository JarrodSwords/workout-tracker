using System;
using System.Collections.Generic;
using System.Linq;

namespace workout_tracker.domain
{
    /// <summary>
    /// For entity compositing
    /// </summary>
    /// <typeparam name="T">Node type</typeparam>
    public class TreeNode<T> where T : Entity
    {
        private List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public List<TreeNode<T>> Children { get { return _children; } }
        public T Content { get; set; }

        public TreeNode()
        {
        }

        public TreeNode(T content)
        {
            Content = content;
        }

        public TreeNode<T> Add(T content)
        {
            _children.Add(new TreeNode<T>(content));
            return this;
        }

        public TreeNode<T> Remove(T content)
        {
            foreach (var child in _children)
            {
                if (child.Content == content)
                {
                    _children.Remove(child);
                    return this;
                }
            }

            return this;
        }
    }

    public class CompositeExercise : Exercise, ICalorieCalculator
    {
        private ICollection<Exercise> _exercises = new List<Exercise>();

        public ICollection<Exercise> Exercises { get => _exercises; }

        public CompositeExercise Add(Exercise exercise)
        {
            _exercises.Add(exercise);
            return this;
        }

        public decimal CalculateCalories(decimal weight)
        {
            var calories = 0m;

            foreach(var exercise in Exercises.OfType<ICalorieCalculator>())
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
