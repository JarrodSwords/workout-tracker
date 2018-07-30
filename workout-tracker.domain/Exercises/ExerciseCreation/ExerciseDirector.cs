namespace workout_tracker.domain
{
    public class ExerciseDirector
    {
        private ExerciseBuilder _exerciseBuilder;

        public void Construct(ExerciseBuilder exerciseBuilder)
        {
            _exerciseBuilder = exerciseBuilder;

            _exerciseBuilder.BuildCardio();
            _exerciseBuilder.BuildResistance();
        }
    }
}
