using System;
using FluentAssertions;
using Moq;
using Xunit;
using workout_tracker.domain;
using CardioExerciseBuilder = workout_tracker.domain.CardioExercise.CardioExerciseBuilder;

namespace workout_tracker.tests.unit
{
    public class CardioExerciseBuilderTest
    {
        [Theory]
        [InlineData(60, 1, 61)]
        public void Build_WithConflictingArgs_ThrowsException(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            Action build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithName("run")
            .WithDistance(new Distance(meters))
            .WithSpeed(new Speed(metersPerSecond))
            .WithTime(new Time(seconds))
            .Build();
            };
            
            build.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(60, 1, 60)]
        public void Build_WithTooFewArgs_ThrowsException(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            Action build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .Build();
            };
            
            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithDistance(new Distance(meters))
            .Build();
            };

            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithName("run")
            .WithSpeed(new Speed(metersPerSecond))
            .Build();
            };

            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithName("run")
            .WithTime(new Time(seconds))
            .Build();
            };

            build.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(60, 1, 60)]
        public void Build_WithValidArgs_ReturnsNewCardioExercise(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var run = new CardioExerciseBuilder()
            .WithName("run")
            .WithDistance(new Distance(meters))
            .WithSpeed(new Speed(metersPerSecond))
            .Build();

            run.Should().NotBeNull();
            run = null;

            run = new CardioExerciseBuilder()
            .WithName("run")
            .WithDistance(new Distance(meters))
            .WithTime(new Time(seconds))
            .Build();

            run.Should().NotBeNull();
            run = null;

            run = new CardioExerciseBuilder()
            .WithName("run")
            .WithSpeed(new Speed(metersPerSecond))
            .WithTime(new Time(seconds))
            .Build();

            run.Should().NotBeNull();
        }
    }
}
