namespace workout_tracker.domain
{
    public class Exercise : Entity, ILocomotionEvent
    {
        private readonly ILocomotionEvent _locomotionEvent;

        public string Name { get; set; }
        public Repetitions Repetitions { get; set; }
        public Sets Sets { get; set; }

        public Distance Distance { get => _locomotionEvent.Distance; }
        public Speed Speed { get => _locomotionEvent.Speed; }
        public Time Time { get => _locomotionEvent.Time; }

        public Exercise(ILocomotionEvent locomotion)
        {
            _locomotionEvent = locomotion;
        }
    }
}
