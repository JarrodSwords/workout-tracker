namespace workout_tracker.domain
{
    public enum ExerciseType
    {
        CardioFree, // e.g. run 5km in 30min
        CardioTimed, // e.g. 10 sets of 1 reps run 1min @ 10km/hr
        ResistanceFree, // e.g. 3 sets of 12 reps 20lb curls
        ResistanceTimed, // e.g. 20lb curls for 1min
        ResistanceToFailure // e.g. 20lb curls
    }
}
