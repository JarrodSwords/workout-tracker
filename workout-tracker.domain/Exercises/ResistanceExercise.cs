namespace workout_tracker.domain
{
    public class ResistanceExercise : IResistanceExercise
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
