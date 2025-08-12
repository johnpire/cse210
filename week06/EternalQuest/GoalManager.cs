using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _streakCount;
    private DateTime _lastActivityDate;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _streakCount = 0;
        _lastActivityDate = DateTime.MinValue;
    }

    public void Start()
    {
        Console.WriteLine("Welcome to the Eternal Quest!\n");

        int choice = -1;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            bool isValidNumber = int.TryParse(input, out choice);
            
            if (isValidNumber)
            {
                if (choice == 1)
                {
                    CreateGoal();
                }
                else if (choice == 2)
                {
                    ListGoalDetails();
                }
                else if (choice == 3)
                {
                    SaveGoals();
                }
                else if (choice == 4)
                {
                    LoadGoals();
                }
                else if (choice == 5)
                {
                    RecordEvent();
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Thanks for using Eternal Quest!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            
            if (choice != 6)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Current Streak: {_streakCount} days");
        string level = GetPlayerLevel();
        Console.WriteLine($"Current Level: {level}");
    }

    private string GetPlayerLevel()
    {
        if (_score >= 10000)
        {
            return "Eternal Light Bearer";
        }
        else if (_score >= 5000)
        {
            return "Celestial Pathfinder";
        }
        else if (_score >= 2500)
        {
            return "Mountain Peak Climber";
        }
        else if (_score >= 1000)
        {
            return "Dawn Seeker";
        }
        else if (_score >= 500)
        {
            return "Growing Soul";
        }
        else
        {
            return "Faithful Walker";
        }
    }

    private void UpdateStreak()
    {
        DateTime today = DateTime.Today;
        
        if (_lastActivityDate == DateTime.MinValue || _lastActivityDate == today)
        {
            if (_lastActivityDate != today)
            {
                _streakCount = 1;
                _lastActivityDate = today;
            }
        }
        else if (_lastActivityDate == today.AddDays(-1))
        {
            _streakCount++;
            _lastActivityDate = today;
        }
        else
        {
            _streakCount = 1;
            _lastActivityDate = today;
        }
    }

    private int GetStreakBonus()
    {
        if (_streakCount >= 30)
        {
            return 500;
        }
        else if (_streakCount >= 7)
        {
            return 150;
        }
        else if (_streakCount >= 3)
        {
            return 50;
        }
        return 0;
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet. Start your quest by creating your first goal!");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string input = Console.ReadLine();
        bool isValidNumber = int.TryParse(input, out int goalType);
        
        if (!isValidNumber || goalType < 1 || goalType > 3)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        string pointsInput = Console.ReadLine();
        bool isValidPoints = int.TryParse(pointsInput, out int points);
        
        if (!isValidPoints)
        {
            Console.WriteLine("Invalid points value.");
            return;
        }

        Goal newGoal = null;

        if (goalType == 1)
        {
            newGoal = new SimpleGoal(name, description, points);
        }
        else if (goalType == 2)
        {
            newGoal = new EternalGoal(name, description, points);
        }
        else if (goalType == 3)
        {
            Console.Write("How many times does this goal need to be accomplished for completion? ");
            string targetInput = Console.ReadLine();
            bool isValidTarget = int.TryParse(targetInput, out int target);
            
            if (!isValidTarget)
            {
                Console.WriteLine("Invalid target value.");
                return;
            }
            
            Console.Write("What is the bonus for accomplishing it that many times? ");
            string bonusInput = Console.ReadLine();
            bool isValidBonus = int.TryParse(bonusInput, out int bonus);
            
            if (!isValidBonus)
            {
                Console.WriteLine("Invalid bonus value.");
                return;
            }
            
            newGoal = new ChecklistGoal(name, description, points, target, bonus);
        }

        if (newGoal != null)
        {
            _goals.Add(newGoal);
            Console.WriteLine("Goal created successfully!");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available. Create a goal first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        string input = Console.ReadLine();
        bool isValidNumber = int.TryParse(input, out int choice);
        
        if (!isValidNumber || choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal selectedGoal = _goals[choice - 1];
        
        if (selectedGoal.IsComplete() && !(selectedGoal is EternalGoal))
        {
            Console.WriteLine("This goal is already complete!");
            return;
        }

        UpdateStreak();
        
        int pointsEarned = selectedGoal.RecordEvent();
        int streakBonus = GetStreakBonus();
        
        _score += pointsEarned + streakBonus;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        
        if (streakBonus > 0)
        {
            Console.WriteLine($"STREAK BONUS! You earned an additional {streakBonus} points for your {_streakCount}-day streak!");
        }
        
        Console.WriteLine($"You now have {_score} points.");

        if (selectedGoal.IsComplete() && selectedGoal is ChecklistGoal)
        {
            Console.WriteLine("AMAZING! You completed your checklist goal! Bonus points awarded!");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        StreamWriter outputFile = new StreamWriter(filename);
        outputFile.WriteLine(_score);
        outputFile.WriteLine(_streakCount);
        outputFile.WriteLine(_lastActivityDate.ToString("yyyy-MM-dd"));
        
        for (int i = 0; i < _goals.Count; i++)
        {
            outputFile.WriteLine(_goals[i].GetStringRepresentation());
        }
        
        outputFile.Close();
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        bool fileExists = File.Exists(filename);
        if (!fileExists)
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        bool isValidScore = int.TryParse(lines[0], out int score);
        if (isValidScore)
        {
            _score = score;
        }

        if (lines.Length > 1 && int.TryParse(lines[1], out int streakCount))
        {
            _streakCount = streakCount;
        }
        
        if (lines.Length > 2 && DateTime.TryParse(lines[2], out DateTime lastActivity))
        {
            _lastActivityDate = lastActivity;
        }
        
        _goals.Clear();

        int startIndex = lines.Length > 2 ? 3 : 1;

        for (int i = startIndex; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(':');
            if (parts.Length != 2)
            {
                continue;
            }

            string goalType = parts[0];
            string[] goalData = parts[1].Split(',');

            Goal goal = null;

            if (goalType == "SimpleGoal")
            {
                if (goalData.Length >= 4)
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    bool isValidPoints = int.TryParse(goalData[2], out int points);
                    bool isValidComplete = bool.TryParse(goalData[3], out bool isComplete);
                    
                    if (isValidPoints && isValidComplete)
                    {
                        goal = new SimpleGoal(name, description, points, isComplete);
                    }
                }
            }
            else if (goalType == "EternalGoal")
            {
                if (goalData.Length >= 3)
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    bool isValidPoints = int.TryParse(goalData[2], out int points);
                    
                    if (isValidPoints)
                    {
                        goal = new EternalGoal(name, description, points);
                    }
                }
            }
            else if (goalType == "ChecklistGoal")
            {
                if (goalData.Length >= 6)
                {
                    string name = goalData[0];
                    string description = goalData[1];
                    bool isValidPoints = int.TryParse(goalData[2], out int points);
                    bool isValidBonus = int.TryParse(goalData[3], out int bonus);
                    bool isValidTarget = int.TryParse(goalData[4], out int target);
                    bool isValidAmount = int.TryParse(goalData[5], out int amountCompleted);
                    
                    if (isValidPoints && isValidBonus && isValidTarget && isValidAmount)
                    {
                        goal = new ChecklistGoal(name, description, points, target, bonus, amountCompleted);
                    }
                }
            }

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Goals loaded successfully!");
    }
}