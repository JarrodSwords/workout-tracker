namespace workout_tracker.domain
{
    public class CardioExerciseBuilder : ExerciseBuilder
    {
        public Repetitions Repetitions { get; }
        public Sets Sets { get; }
        public Distance Distance { get; }
        public Speed Speed { get; }
        public Time Time { get; }

        public CardioExerciseBuilder(ExerciseType exerciseType, string name, Repetitions repetitions, Sets sets, Distance distance, Speed speed)
        : base(exerciseType, name)
        {
            Repetitions = repetitions;
            Sets = sets;
            Distance = distance;
            Speed = speed;
        }

        public CardioExerciseBuilder(ExerciseType exerciseType, string name, Repetitions repetitions, Sets sets, Speed speed, Time time)
        : base(exerciseType, name)
        {
            Repetitions = repetitions;
            Sets = sets;
            Speed = speed;
            Time = time;
            Time = time;
        }

        public override void BuildCardio()
        {
            switch (Exercise.ExerciseType)
            {
                case ExerciseType.CardioFree:
                    Exercise.CardioExercise = new CardioExercise(Distance, Speed);
                    break;
                case ExerciseType.CardioTimed:
                default:
                    Exercise.CardioExercise = new CardioExercise(Speed, Time);
                    break;
            }

            Exercise.Repetitions = Repetitions;
            Exercise.Sets = Sets;
        }
    }
}
