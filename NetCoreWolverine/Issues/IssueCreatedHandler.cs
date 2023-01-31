namespace NetCoreWolverine.Issues;

public static class IssueCreatedHandler
{
    public static Task Handle(IssueCreated created, DateTimerProvider dateTimerProvider)
    {
        var issue = Store.Issues.FirstOrDefault(a => a.Id == created.Id);
        
        // sendmail
        Console.WriteLine($"now : {dateTimerProvider.Now():s}");
        Console.WriteLine($"send mail : {issue}");

        return Task.CompletedTask;
    }
}