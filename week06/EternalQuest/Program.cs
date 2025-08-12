// CREATIVITY ADDITION: Streak Bonus System 
// Added a streak tracking system that rewards consecutive days of activity:
// - Users maintain a daily activity streak when they record any goal event
// - Streak bonuses: 3-day streak = 50 bonus points, 7-day streak = 150 bonus points, 
//   30-day streak = 500 bonus points
// - The system tracks the last activity date and current streak count
// - Level titles are themed around mystical quest progression with emojis
// - Streak information is displayed in player info and saved/loaded with goals
// 
// This gamification element encourages daily engagement and provides additional
// motivation through milestone rewards, fitting the "Eternal Quest" theme perfectly.
//

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}