using System;
using FluentAssertions;
using Moq;
using UnitsNet;
using UnitsNet.Units;
using Xunit;
using workout_tracker.domain;
using CardioExerciseBuilder = workout_tracker.domain.CardioExercise.CardioExerciseBuilder;

namespace workout_tracker.tests.unit
{
    public class CardioExerciseBuilderTest
    {
        private Tuple<Duration, Length, Speed> CreateMeasurements(
            double durationQuantity, string durationUnitName,
            double lengthQuantity, string lengthUnitName,
            double speedQuantity, string speedUnitName)
        {
            return new Tuple<Duration, Length, Speed>(
                new Duration(durationQuantity, durationUnitName.ToEnum<DurationUnit>()),
                new Length(lengthQuantity, lengthUnitName.ToEnum<LengthUnit>()),
                new Speed(speedQuantity, speedUnitName.ToEnum<SpeedUnit>())
                );
        }

        [Theory]
        [InlineData(2, "Minute", 528, "Foot", 6, "MilePerHour")]
        [InlineData(1, "Minute", 529, "Foot", 6, "MilePerHour")]
        [InlineData(1, "Minute", 528, "Foot", 7, "MilePerHour")]
        public void Build_WithConflictingMeasurements_ThrowsException(
            double durationQuantity, string durationUnitName,
            double lengthQuantity, string lengthUnitName,
            double speedQuantity, string speedUnitName)
        {
            var measurements = CreateMeasurements(durationQuantity, durationUnitName, lengthQuantity, lengthUnitName, speedQuantity, speedUnitName);

            Action build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithDuration(measurements.Item1)
            .WithLength(measurements.Item2)
            .WithSpeed(measurements.Item3)
            .Build();
            };

            build.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(1, "Minute", 528, "Foot", 6, "MilePerHour")]
        [InlineData(1, "Minute", 300, "Meter", 5, "MeterPerSecond")]
        public void Build_WithInsufficientMeasurements_ThrowsException(
            double durationQuantity, string durationUnitName,
            double lengthQuantity, string lengthUnitName,
            double speedQuantity, string speedUnitName)
        {
            var measurements = CreateMeasurements(durationQuantity, durationUnitName, lengthQuantity, lengthUnitName, speedQuantity, speedUnitName);

            Action build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .Build();
            };

            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithDuration(measurements.Item1)
            .Build();
            };

            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithLength(measurements.Item2)
            .Build();
            };

            build.Should().Throw<Exception>();

            build = () =>
            {
                var exercise = new CardioExerciseBuilder()
            .WithSpeed(measurements.Item3)
            .Build();
            };

            build.Should().Throw<Exception>();
        }

        [Theory]
        [InlineData(1, "Minute", 528, "Foot", 6, "MilePerHour")]
        [InlineData(1, "Minute", 300, "Meter", 5, "MeterPerSecond")]
        public void Build_WithValidMeasurements_ReturnsCardioExercise(
            double durationQuantity, string durationUnitName,
            double lengthQuantity, string lengthUnitName,
            double speedQuantity, string speedUnitName)
        {
            var measurements = CreateMeasurements(durationQuantity, durationUnitName, lengthQuantity, lengthUnitName, speedQuantity, speedUnitName);
            
            var exercise = new CardioExerciseBuilder()
            .WithDuration(measurements.Item1)
            .WithLength(measurements.Item2)
            .Build();

            exercise.Should().NotBeNull();

            exercise = null;
            exercise = new CardioExerciseBuilder()
            .WithDuration(measurements.Item1)
            .WithSpeed(measurements.Item3)
            .Build();

            exercise.Should().NotBeNull();

            exercise = null;
            exercise = new CardioExerciseBuilder()
            .WithLength(measurements.Item2)
            .WithSpeed(measurements.Item3)
            .Build();

            exercise = null;
            exercise = new CardioExerciseBuilder()
            .WithDuration(measurements.Item1)
            .WithLength(measurements.Item2)
            .WithSpeed(measurements.Item3)
            .Build();

            exercise.Should().NotBeNull();
        }
    }
}
