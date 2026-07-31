using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

static void Calculate_avgaandlevel(int[]grades,ref double avg,ref string level)
{
    double sum = 0;
    for (int i = 0; i < grades.Length; i++)
    {
        sum += grades[i];
    }
    avg = sum / grades.Length;


    if (avg >= 0.0 && avg < 20)
    {
        level = "Freshman";
    }
    else if (avg >= 20 && avg < 40)
    {
        level = "Sophomore";
    }
    else if (avg >= 40 && avg < 60)
    {
        level = "Junior";
    }
    else if (avg >= 60 && avg <= 100)
    {
        level = "Senior";
    }
}

static void display(string name,int[] grades,  double avg, string level)
{
    Console.WriteLine("------------------------");
    Console.WriteLine($"Student Name : {name}");

    Console.Write($"Grades : ");
    for (int i = 0; i < grades.Length; i++)
    {
        Console.Write($"{grades[i]} ");
    }
    Console.WriteLine();
    Console.WriteLine($"Average : {avg}");

    Console.WriteLine($"level : {level}");
    Console.WriteLine("------------------------");
}

    double avg = 0;
    Console.WriteLine("Enter your name : ");
    string name = Console.ReadLine();

    int[] grades = new int[5];

    for (int i = 0; i < grades.Length; i++)
    {
        Console.WriteLine($"Enter your grade {i + 1} : ");
        grades[i] = int.Parse(Console.ReadLine());
    }
    String level = " ";

    Calculate_avgaandlevel(grades, ref avg,ref level);
    display(name, grades,  avg, level);
