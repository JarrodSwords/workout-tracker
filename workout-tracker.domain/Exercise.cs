namespace workout_tracker.domain
{
    public class Exercise : Entity
    {
        private readonly ExerciseType _exerciseType;

        public ICardioExercise CardioExercise { get; set; }
        public IResistanceExercise ResistanceExercise { get; set; }

        public string Name { get; set; }
        public Repetitions Repetitions { get; set; }
        public Sets Sets { get; set; }

        public Exercise(ExerciseType exerciseType, string name)
        {
            _exerciseType = exerciseType;
            Name = name;
        }
    }
}
