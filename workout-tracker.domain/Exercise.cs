namespace workout_tracker.domain
{
    public class Exercise : Entity
    {
        private readonly ICardio _cardio;
        private readonly IResistance _resistance;

        public string Name { get; set; }
        public Repetitions Repetitions { get; set; }
        public Sets Sets { get; set; }

        public Exercise(ICardio locomotion, IResistance resistance)
        {
            _cardio = locomotion;
            _resistance = resistance;
        }
    }
}
