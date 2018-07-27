using System;
using FluentAssertions;
using Moq;
using Xunit;
using workout_tracker.domain;

namespace workout_tracker.tests.unit
{
    public class LocomotionEventTest
    {
        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateDistance_WithSpeedAndTime_ReturnsDistance(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var distance = LocomotionEvent.CalculateDistance(new Speed(metersPerSecond), new Time(seconds));
            
            distance.Meters.Should().Be(meters);
        }

        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateSpeed_WithDistanceAndTime_ReturnsSpeed(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var speed = LocomotionEvent.CalculateSpeed(new Distance(meters), new Time(seconds));
            
            speed.MetersPerSecond.Should().Be(metersPerSecond);
        }

        [Theory]
        [InlineData(60, 1, 60)]
        [InlineData(7200, 2, 3600)]
        public void CalculateTime_WithDistanceAndSpeed_ReturnsTime(decimal meters, decimal metersPerSecond, decimal seconds)
        {
            var time = LocomotionEvent.CalculateTime(new Distance(meters), new Speed(metersPerSecond));
            
            time.Seconds.Should().Be(seconds);
        }

        [Theory]
        [InlineData(-60, 1)]
        [InlineData(60, -1)]
        public void DistanceSpeedConstructor_WithNegativeArgs_ThrowsArgumentOutOfRangeException(decimal meters, decimal metersPerSecond)
        {
            Action act = () => new LocomotionEvent(new Distance(meters), new Speed(metersPerSecond));

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-1, 60)]
        [InlineData(1, -60)]
        public void SpeedTimeConstructor_WithNegativeArgs_ThrowsArgumentOutOfRangeException(decimal metersPerSecond, decimal seconds)
        {
            Action act = () => new LocomotionEvent(new Speed(metersPerSecond), new Time(seconds));

            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(-60, 60)]
        [InlineData(60, -60)]
        public void DistanceTimeConstructor_WithNegativeArgs_ThrowsArgumentOutOfRangeException(decimal meters, decimal seconds)
        {
            Action act = () => new LocomotionEvent(new Distance(meters), new Time(seconds));

            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
