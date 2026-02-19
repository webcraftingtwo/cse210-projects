using System;

public abstract class Activity
{
    // Encapsulation: private member variables
    private string _date;
    private int _minutes;

    public Activity(string date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public int GetMinutes()
    {
        return _minutes;
    }

    // Virtual methods to be overridden
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // The summary method that uses the other virtual methods (Polymorphism)
    public string GetSummary()
    {
        return $"{_date} {this.GetType().Name} ({_minutes} min) - Distance {GetDistance():0.0} km, Speed {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
