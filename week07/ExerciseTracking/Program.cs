using System;

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running(DateTime.Now, 30, 5.0),
            new Cycling(DateTime.Now, 40, 20.0),
            new Swimming(DateTime.Now, 25, 30)
        };

        foreach (var activity in activities)
        {
            activity.GetSummary();
        }
    }
}
