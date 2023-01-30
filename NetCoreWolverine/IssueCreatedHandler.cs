public static class IssueCreatedHandler
{
    public static Task Handle(IssueCreated created)
    {
        var issue = Store.Issues.FirstOrDefault(a => a.Id == created.Id);
        
        // sendmail
        Console.WriteLine($"send mail : {issue}");

        return Task.CompletedTask;
    }
}