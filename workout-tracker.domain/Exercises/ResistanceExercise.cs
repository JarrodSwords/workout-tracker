namespace workout_tracker.domain
{
    public class ResistanceExercise : Exercise
    {
        public bool IsToFailure { get; }
        public Resistance Resistance { get; }

        public ResistanceExercise(bool isToFailure, Resistance resistance, string name = null, Repetitions repetitions = null, Sets sets = null)
        : base(name, "Resistance Exercise", repetitions, sets)
        {
            IsToFailure = isToFailure;
            Resistance = resistance;
        }
    }
}
