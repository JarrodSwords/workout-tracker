namespace workout_tracker.domain
{
    public class ResistanceExerciseBuilder : ExerciseBuilder
    {
        public bool IsToFailure { get; }
        public Repetitions Repetitions { get; }
        public Resistance Resistance { get; }
        public Time Time { get; }

        public ResistanceExerciseBuilder(ExerciseType exerciseType, string name, bool isToFailure, Repetitions repetitions, Resistance resistance, Time time)
        : base(exerciseType, name)
        {
            IsToFailure = isToFailure;
            Repetitions = repetitions;
            Resistance = resistance;
            Time = time;
        }

        public override void BuildResistance()
        {
            Exercise.ResistanceExercise = new ResistanceExercise(IsToFailure, Resistance);
            Exercise.Repetitions = Repetitions;
            Exercise.Sets = new Sets(1);
        }
    }
}
