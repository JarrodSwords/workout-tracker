namespace workout_tracker.domain
{
    public class Exercise : Entity
    {
        public ExerciseType ExerciseType { get; set; }
        public string Name { get; set; }
        public Repetitions Repetitions { get; set; }
        public Sets Sets { get; set; }

        protected Exercise(Repetitions repetitions = null, Sets sets = null)
        {
            Repetitions = repetitions ?? new Repetitions(1);
            Sets = sets ?? new Sets(1);
        }
    }
}
