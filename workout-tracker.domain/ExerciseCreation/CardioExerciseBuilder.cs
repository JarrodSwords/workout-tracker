namespace workout_tracker.domain
{
    public class CardioExerciseBuilder : ExerciseBuilder
    {
        public Repetitions Repetitions { get; }
        public Sets Sets { get; }
        public Distance Distance { get; }
        public Speed Speed { get; }

        public CardioExerciseBuilder(ExerciseType exerciseType, string name, Repetitions repetitions, Sets sets, Distance distance, Speed speed)
        : base(exerciseType, name)
        {
            Repetitions = repetitions;
            Sets = sets;
            Distance = distance;
            Speed = speed;
        }

        public override void BuildCardio()
        {
            Exercise.CardioExercise = new CardioExercise(Distance, Speed);
            Exercise.Repetitions = Repetitions;
            Exercise.Sets = Sets;
        }
    }
}
