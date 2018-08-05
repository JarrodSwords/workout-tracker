using System;
using FluentAssertions;
using Moq;
using Xunit;
using workout_tracker.domain;
using CardioExerciseBuilder = workout_tracker.domain.CardioExercise.CardioExerciseBuilder;

namespace workout_tracker.tests.unit
{
    public class CardioExerciseTest
    {
        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateDistance_WithSpeedAndTime_ReturnsDistance(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var distance = CardioExercise.CalculateDistance(new Speed(metersPerSecond), new Time(seconds));

            distance.Meters.Should().Be(meters);
        }

        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateSpeed_WithDistanceAndTime_ReturnsSpeed(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var speed = CardioExercise.CalculateSpeed(new Distance(meters), new Time(seconds));

            speed.MetersPerSecond.Should().Be(metersPerSecond);
        }

        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateTime_WithDistanceAndSpeed_ReturnsTime(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var time = CardioExercise.CalculateTime(new Distance(meters), new Speed(metersPerSecond));

            time.Seconds.Should().Be(seconds);
        }
    }
}
