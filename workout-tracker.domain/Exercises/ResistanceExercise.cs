namespace workout_tracker.domain
{
    public class ResistanceExercise : Exercise
    {
        public bool IsToFailure { get; }
        public Resistance Resistance { get; }

        public ResistanceExercise(bool isToFailure, Resistance resistance)
        {
            IsToFailure = isToFailure;
            Resistance = resistance;
        }
    }
}
