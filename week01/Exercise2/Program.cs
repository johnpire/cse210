using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? (Input only the numbers) ");
        string userGradePercentage = Console.ReadLine();

        int userGradePercentageInt = int.Parse(userGradePercentage);

        string grade = "";
        
        if (userGradePercentageInt > 100 || userGradePercentageInt < 0)
        {
            Console.WriteLine("Please only input numbers 0-100");
        }
        else if (userGradePercentageInt >= 90)
        {
            grade = "A";
        }
        else if (userGradePercentageInt >= 80)
        {
            grade = "B";
        }
        else if (userGradePercentageInt >= 70)
        {
            grade = "C";
        }
        else if (userGradePercentageInt >= 60)
        {
            grade = "D";
        }
        else
        {
            grade = "F";
        }

        int gradeLastDigit = (userGradePercentageInt % 10);
        string sign = "";
        if (grade == "B" || grade == "C" || grade == "D")
        {
            if (gradeLastDigit >= 7)
            {
                sign = "+";
            }
            else if (gradeLastDigit < 3)
            {
                sign = "-";
            }
            else
            {
                sign = "";
            }
        }
        else if (grade == "A")
        {
            if (gradeLastDigit < 3)
            {
                sign = "-";
            }
        }

        Console.WriteLine($"Your grade is {grade}{sign}");

        if (userGradePercentageInt >= 70 && userGradePercentageInt <= 100)
        {
            Console.WriteLine("Congratulations! You have succesfully passed!");
        }
        else if (userGradePercentageInt < 70 && userGradePercentageInt >= 0)
        {
            Console.WriteLine("I am sorry but you have failed. However, this doesn't synonymize to falling, nor is it a setback, but rather a lesson... a grand step in disguise towards your path to success.");
        }
    }
}