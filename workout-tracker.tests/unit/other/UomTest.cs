using System;
using System.Linq;
using FluentAssertions;
using Moq;
using Xunit;
using UnitsNet;
using UnitsNet.Units;

namespace workout_tracker.tests
{
    public class UomTest
    {
        [Fact]
        public void GetDistance()
        {
            var speed = new Speed(6, SpeedUnit.MilePerHour);
            var duration = new Duration(1, DurationUnit.Minute);
            var distance = speed * duration;

            distance.Should().BeEquivalentTo(new Length(528, LengthUnit.Foot));
        }
    }
}
