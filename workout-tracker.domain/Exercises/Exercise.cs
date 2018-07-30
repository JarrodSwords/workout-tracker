namespace workout_tracker.domain
{
    public class Exercise : Entity
    {
        public ExerciseType ExerciseType { get; set; }
        public string Name { get; set; }
        public Repetitions Repetitions { get; set; }
        public Sets Sets { get; set; }

        public ICardioExercise CardioExercise { get; set; }
        public IResistanceExercise ResistanceExercise { get; set; }

        public Exercise(ExerciseType exerciseType, string name)
        {
            ExerciseType = exerciseType;
            Name = name;
        }
    }
}
