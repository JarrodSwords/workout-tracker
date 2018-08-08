using System;
using UnitsNet;
using workout_tracker.domain;

namespace workout_tracker.domain
{
    public class CardioExercise : Exercise
    {
        public Duration Duration { get; }
        public Length Length { get; }
        public Speed Speed { get; }

        private CardioExercise(Duration duration, Length length, Speed speed, string name = null, Repetitions repetitions = null, Sets sets = null)
        : base(name, "Cardio Exercise", repetitions, sets)
        {
            Duration = duration;
            Length = length;
            Speed = speed;
        }

        public static Duration CalculateDuration(Length length, Speed speed)
        {
            return length / speed;
        }

        public static Length CalculateLength(Duration duration, Speed speed)
        {
            return speed * duration;
        }

        public static Speed CalculateSpeed(Duration duration, Length length)
        {
            return length / duration;
        }

        public sealed class CardioExerciseBuilder
        {
            private string _name;
            private Duration? _duration;
            private Length? _length;
            private Speed? _speed;
            private Repetitions _repetitions;
            private Sets _sets;

            public CardioExerciseBuilder WithName(string name)
            {
                _name = name;
                return this;
            }

            public CardioExerciseBuilder WithDuration(Duration duration)
            {
                _duration = duration;
                return this;
            }

            public CardioExerciseBuilder WithLength(Length length)
            {
                _length = length;
                return this;
            }

            public CardioExerciseBuilder WithSpeed(Speed speed)
            {
                _speed = speed;
                return this;
            }

            public CardioExerciseBuilder WithRepetitions(Repetitions repetitions)
            {
                _repetitions = repetitions;
                return this;
            }

            public CardioExerciseBuilder WithSets(Sets sets)
            {
                _sets = sets;
                return this;
            }

            private bool CompleteMeasurements()
            {
                const bool IS_COMPLETE = true;

                if (_duration.HasValue && _length.HasValue && _speed.HasValue)
                {
                    return IS_COMPLETE;
                }
                else if (_length.HasValue && _speed.HasValue)
                {
                    _duration = CardioExercise.CalculateDuration(_length.Value, _speed.Value);
                    return IS_COMPLETE;
                }
                else if (_duration.HasValue && _speed.HasValue)
                {
                    _length = CardioExercise.CalculateLength(_duration.Value, _speed.Value);
                    return IS_COMPLETE;
                }
                else if (_duration.HasValue && _length.HasValue)
                {
                    _speed = CardioExercise.CalculateSpeed(_duration.Value, _length.Value);
                    return IS_COMPLETE;
                }

                return !IS_COMPLETE;
            }

            private static bool ValidateMeasurements(Duration duration, Length length, Speed speed)
            {
                return length.Equals(CalculateLength(duration, speed));
            }

            public CardioExercise Build()
            {
                var isComplete = CompleteMeasurements();
                if (!isComplete)
                    throw new Exception("Cardio exercises must be built with at least two of duration, length, and speed.");

                var isValid = ValidateMeasurements(_duration.Value, _length.Value, _speed.Value);
                if (!isValid)
                    throw new Exception("Cardio exercise has a measurement contradiction.");

                return new CardioExercise(_duration.Value, _length.Value, _speed.Value, _name, _repetitions, _sets);
            }
        }
    }
}
