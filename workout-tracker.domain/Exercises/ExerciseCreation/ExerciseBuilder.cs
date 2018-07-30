namespace workout_tracker.domain
{
    public abstract class ExerciseBuilder
    {
        public Exercise Exercise { get; private set; }

        public ExerciseBuilder(ExerciseType exerciseType, string name)
        {
            Exercise = new Exercise(exerciseType, name);
        }

        public virtual void BuildCardio()
        {
        }

        public virtual void BuildResistance()
        {
        }
    }
}
