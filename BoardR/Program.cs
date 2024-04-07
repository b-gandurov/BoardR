using BoardR;
using Task = BoardR.Task;

class Program
{
    static void Main(string[] args)
    {
        var tomorrow = DateTime.Now.AddDays(1);
        var issue = new Issue("App flow tests?", "We need to test the App!", tomorrow);
        var task = new Task("Test the application flow", "Peter", tomorrow);

        Board.AddItem(issue);
        Board.AddItem(task);
        Console.WriteLine(Board.TotalItems); // 2
        Console.WriteLine(Board.PrintItems());

        //var issue = new Issue("App flow tests?", "We need to test the App!", DateTime.Now.AddDays(1));
        //issue.AdvanceStatus();
        //issue.DueDate = issue.DueDate.AddDays(1);
        //Console.WriteLine(issue.ViewHistory());
        //var issue2 = new Issue("dwadawdawdadwad", "", DateTime.Now.AddDays(1));
        //Console.WriteLine(issue2.ViewHistory());

        //var task = new Task("Test the application flow", "Peter", DateTime.Now.AddDays(1));
        //task.AdvanceStatus();
        //task.AdvanceStatus();
        //task.Assignee = "George";
        //Console.WriteLine(task.ViewHistory());

    }
}