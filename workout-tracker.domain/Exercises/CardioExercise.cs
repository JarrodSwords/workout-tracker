using System;
using workout_tracker.domain;

namespace workout_tracker.domain
{
    public class CardioExercise : Exercise, ICalorieCalculator
    {
        public Distance Distance { get; }
        public Speed Speed { get; }
        public Time Time { get; }

        private CardioExercise(Distance distance, Speed speed, Time time, Repetitions repetitions = null, Sets sets = null)
        : base(repetitions, sets)
        {
            this.Distance = distance;
            this.Speed = speed;
            this.Time = time;
            this.Repetitions = repetitions;
            this.Sets = sets;
        }

        public static Distance CalculateDistance(Speed speed, Time time)
        {
            return new Distance(speed.MetersPerSecond * time.Seconds);
        }

        public static Speed CalculateSpeed(Distance distance, Time time)
        {
            return new Speed(distance.Meters / time.Seconds);
        }

        public static Time CalculateTime(Distance distance, Speed speed)
        {
            return new Time(distance.Meters / speed.MetersPerSecond);
        }

        public decimal CalculateCalories(decimal weight)
        {
            var calorieCalculator = Speed.MetersPerSecond > 2.2m
            ? (ICalorieCalculator)new RunningCalorieCalculator()
            : (ICalorieCalculator)new WalkingCalorieCalculator();

            return calorieCalculator.CalculateCalories(weight);
        }

        public sealed class CardioExerciseBuilder
        {
            private Distance _distance;
            private Speed _speed;
            private Time _time;
            private string _name;
            private Repetitions _repetitions;
            private Sets _sets;

            public CardioExerciseBuilder WithName(string name)
            {
                _name = name;
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

            public CardioExerciseBuilder WithDistance(Distance distance)
            {
                _distance = distance;
                return this;
            }

            public CardioExerciseBuilder WithSpeed(Speed speed)
            {
                _speed = speed;
                return this;
            }

            public CardioExerciseBuilder WithTime(Time time)
            {
                _time = time;
                return this;
            }

            private void Complete()
            {
                if (_distance == null)
                    _distance = CardioExercise.CalculateDistance(_speed, _time);
                else if (_speed == null)
                    _speed = CardioExercise.CalculateSpeed(_distance, _time);
                else if (_time == null)
                    _time = CardioExercise.CalculateTime(_distance, _speed);
            }

            private static void Validate(Distance distance, Speed speed, Time time)
            {
                if (distance.Meters != CalculateDistance(speed, time).Meters)
                    throw new ArgumentOutOfRangeException();
            }

            public CardioExercise Build()
            {
                Complete();
                Validate(_distance, _speed, _time);
                return new CardioExercise(_distance, _speed, _time, _repetitions, _sets);
            }
        }
    }
}
