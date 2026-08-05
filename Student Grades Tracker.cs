using System;
using System.Collections.Generic;

enum Level
{
    Freshman,
    Sophomore,
    Junior,
    Senior
}

class Program
{
    static void CalculateAvgAndLevel(List<int> grades, ref double avg, ref Level level)
    {
        double sum = 0;

        for (int i = 0; i < grades.Count; i++)
        {
            sum += grades[i];
        }

        avg = sum / grades.Count;

        if (avg >= 0 && avg < 20)
            level = Level.Freshman;
        else if (avg >= 20 && avg < 40)
            level = Level.Sophomore;
        else if (avg >= 40 && avg < 60)
            level = Level.Junior;
        else
            level = Level.Senior;
    }

    static void Display(string name, List<int> grades, double avg, Level level)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"Student Name : {name}");

        Console.Write("Grades : ");
        for (int i = 0; i < grades.Count; i++)
        {
            Console.Write(grades[i] + " ");
        }

        Console.WriteLine();
        Console.WriteLine($"Average : {avg:F2}");
        Console.WriteLine($"Level : {level}");
        Console.WriteLine("------------------------");
    }

    static void Main()
    {
        Dictionary<string, List<int>> dic = new Dictionary<string, List<int>>();

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        List<int> grades = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Enter grade {i + 1}: ");
            grades.Add(int.Parse(Console.ReadLine()));
        }

        dic.Add(name, grades);

        double avg = 0;
        Level level = Level.Freshman;

        CalculateAvgAndLevel(dic[name], ref avg, ref level);

        Display(name, dic[name], avg, level);
    }
}
