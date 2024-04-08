using BoardR;
using Task = BoardR.Task;


class Program
{
    static void Main(string[] args)
    {
        //var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
        //task.AdvanceStatus();
        //task.AdvanceStatus();
        //task.AdvanceStatus();
        //task.AdvanceStatus();
        //task.Assignee = "George";
        //task.Title = "Title";
        //Console.WriteLine(task.ViewHistory());
        //Console.WriteLine(task.ViewInfo());

        var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
        Console.WriteLine(issue.Title); // App flow tests?
        Console.WriteLine(issue.Description); // We need to test the App!
        Console.WriteLine(issue.Status); // Open
        Console.WriteLine(issue.ViewInfo());
        Console.WriteLine(issue.ViewInfoDetailed());
    }
}