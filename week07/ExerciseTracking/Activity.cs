using System;

abstract class Activity
{
    private int _minutes;
    private DateTime _date;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    protected int GetMinutes()
    {
        return _minutes;
    }

    public string GetDate()
    {
        return _date.ToString("dd/MM/yyyy");
    }

    public abstract double GetDistance(); // km

    public abstract double GetSpeed(); // kph

    public abstract double GetPace(); // min/km

    public virtual void GetSummary()
    {
        Console.WriteLine($"{GetDate()} {GetType().Name} ({GetMinutes()} min)- Distance {GetDistance(): 0.0} km, Speed: {GetSpeed(): 0.0} kph, Pace: {GetPace(): 0.00}");
        //myNote: GetType will get the type of the object, and .name will return the name
    }
}
