using BoardR;
using Task = BoardR.Task;


class Program
{
    static void Main(string[] args)
    {
        var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
        task.AdvanceStatus();
        task.AdvanceStatus();
        task.Assignee = "George";
        Console.WriteLine(task.ViewHistory());
    }
}