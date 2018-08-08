using System;
using FluentAssertions;
using Moq;
using UnitsNet;
using UnitsNet.Units;
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
            .WithDuration(new Duration(1, DurationUnit.Minute))
            .WithSpeed(new Speed(8, SpeedUnit.MilePerHour))
            .Build();

            var walk = new CardioExerciseBuilder()
            .WithName("walk")
            .WithDuration(new Duration(1, DurationUnit.Minute))
            .WithSpeed(new Speed(3, SpeedUnit.MilePerHour))
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
        }
    }
}
