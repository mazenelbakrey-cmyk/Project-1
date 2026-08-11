enum TaskStatus
{
    Pending,
    Completed
}

public class TaskDetails
{
    public string Name;
    public string Description;
    public TaskStatus Status;
}

public class ToDoApp
{
    List<TaskDetails> Tasks = new List<TaskDetails>();

    public ToDoApp()
    {
        Console.WriteLine("1-Add Task . ");
        Console.WriteLine("2-View Task . ");
        Console.WriteLine("3-Mark Task as Complete . ");
        Console.WriteLine("4-Remove Task . ");
        Console.WriteLine("5-Exit . ");
    }

    public void AddTask()
    {
        TaskDetails task = new TaskDetails();

        Console.Write("Enter Task Name: ");
        task.Name = Console.ReadLine();

        Console.Write("Enter Task Description: ");
        task.Description = Console.ReadLine();

        task.Status = TaskStatus.Pending;

        Tasks.Add(task);

        Console.WriteLine("Task added successfully.");
    }

    public void ViewTask()
    {
        Console.WriteLine("Your Tasks:");

        for (int i = 0; i < Tasks.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Tasks[i].Name} - {Tasks[i].Status}");
            Console.WriteLine($"   Description: {Tasks[i].Description}");
        }
    }

    public void MarkTaskAsComplete()
    {
        Console.Write("Enter Task number to mark as Complete: ");

        int number = int.Parse(Console.ReadLine());
        number--;

        if (number >= 0 && number < Tasks.Count)
        {
            Tasks[number].Status = TaskStatus.Completed;

            Console.WriteLine("Task marked as complete.");
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }

    public void RemoveTask()
    {
        Console.Write("Enter Task number to remove: ");

        int number = int.Parse(Console.ReadLine());
        number--;

        if (number >= 0 && number < Tasks.Count)
        {
            Tasks.RemoveAt(number);

            Console.WriteLine("Task removed successfully.");
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
}

class Program
{
    enum ListApp
    {
        AddTask = 1,
        ViewTask,
        Mark_task_as_complete,
        RemoveTask,
        Exit
    }

    static void Main()
    {
        bool loop = true;
        ToDoApp app = new ToDoApp();

        while (loop)
        {
            Console.WriteLine("Choose an option : ");

            int choice = int.Parse(Console.ReadLine());

            ListApp number = (ListApp)choice;

            switch (number)
            {
                case ListApp.AddTask:
                    app.AddTask();
                    break;

                case ListApp.ViewTask:
                    app.ViewTask();
                    break;

                case ListApp.Mark_task_as_complete:
                    app.MarkTaskAsComplete();
                    break;

                case ListApp.RemoveTask:
                    app.RemoveTask();
                    break;

                case ListApp.Exit:
                    loop = false;
                    break;

                default:
                    Console.WriteLine("enter a valid option : ");
                    break;
            }
        }
    }
}
