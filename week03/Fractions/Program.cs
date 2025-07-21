using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction test = new Fraction();

        test.SetBottom(3);

        test.GetTop();
        test.GetBottom();

        Console.WriteLine(test.GetFractionString());
        Console.WriteLine(test.GetDecimalValue());
    }
}