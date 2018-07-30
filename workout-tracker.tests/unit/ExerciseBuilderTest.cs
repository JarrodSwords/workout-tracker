using System;
using FluentAssertions;
using Moq;
using Xunit;
using workout_tracker.domain;

namespace workout_tracker.tests.unit
{
    public class ExerciseBuilderTest
    {
        [Fact]
        public void CreateBicepCurls_WithValidArgs_BuildsBicepCurlsExercise()
        {
            var director = new ExerciseDirector();
            var builder = new ResistanceExerciseBuilder(ExerciseType.ResistanceToFailure, "bicep curls", true, new Repetitions(12), new Resistance(20), null);

            director.Construct(builder);

            builder.Exercise.Should().NotBeNull();
        }

        [Fact]
        public void CreateDistanceRun_WithValidArgs_BuildsDistanceRunExercise()
        {
            var director = new ExerciseDirector();
            var builder = new CardioExerciseBuilder(ExerciseType.Cardio, "distance run", new Repetitions(1), new Sets(1), new Distance(15), new Speed(5));

            director.Construct(builder);

            builder.Exercise.Should().NotBeNull();
        }
    }
}
