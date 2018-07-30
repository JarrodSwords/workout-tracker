using workout_tracker.domain;

public class LocomotionEvent : ILocomotionEvent
{
    public Distance Distance { get; }
    public Speed Speed { get; }
    public Time Time { get; }

    public LocomotionEvent(Distance distance, Speed speed)
    {
        this.Distance = distance;
        this.Speed = speed;
        this.Time = CalculateTime(distance, speed);
    }

    public LocomotionEvent(Speed speed, Time time)
    {
        this.Distance = CalculateDistance(speed, time);
        this.Speed = speed;
        this.Time = time;
    }

    public LocomotionEvent(Distance distance, Time time)
    {
        this.Distance = distance;
        this.Speed = CalculateSpeed(distance, time);
        this.Time = time;
    }

    public static Distance CalculateDistance(Speed speed, Time time)
    {
        return new Distance(speed.MetersPerSecond * time.Seconds);
    }

    public static Speed CalculateSpeed(Distance distance, Time time)
    {
        return new Speed(distance.Meters / time.Seconds);
    }

    public static Time CalculateTime(Distance distance, Speed speed)
    {
        return new Time(distance.Meters / speed.MetersPerSecond);
    }
}
