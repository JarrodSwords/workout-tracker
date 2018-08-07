using System;
using FluentAssertions;
using Moq;
using Xunit;
using workout_tracker.domain;
using CardioExerciseBuilder = workout_tracker.domain.CardioExercise.CardioExerciseBuilder;
using CompositeExerciseBuilder = workout_tracker.domain.CompositeExercise.CompositeExerciseBuilder;

namespace workout_tracker.tests.unit
{
    public class CompositeExerciseTest
    {
        [Fact]
        public void CreateIntervals_WithSprintAndWalk_ReturnsIntervalExercise()
        {
            var sprint = new CardioExerciseBuilder()
            .WithName("sprint")
            .WithSpeed(new Speed(3.5m))
            .WithTime(new Time(60m))
            .Build();

            var walk = new CardioExerciseBuilder()
            .WithName("walk")
            .WithSpeed(new Speed(1.4m))
            .WithTime(new Time(60m))
            .Build();

            var intervals = new CompositeExerciseBuilder()
            .WithName("intervals")
            .WithSets(new Sets(10))
            .Build();

            intervals
            .Add(sprint)
            .Add(walk);

            intervals.Exercises.Should().Contain(sprint);
            intervals.Exercises.Should().Contain(walk);

            intervals.CalculateCalories(74);
        }
    }
}
