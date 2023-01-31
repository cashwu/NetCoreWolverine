namespace NetCoreWolverine.Issues;

public class CreateIssueHandler
{
    // private readonly DateTimerProvider _dateTimerProvider;
    //
    // public CreateIssueHandler(DateTimerProvider dateTimerProvider)
    // {
    //     _dateTimerProvider = dateTimerProvider;
    // }
    
    public IssueCreated Handle(CreateIssue command, DateTimerProvider dateTimerProvider)
    {
        var issue = new Issue
        {
            Id = command.Id,
            Title = command.Title,
            Desc = command.Desc 
        };
        
        Store.Issues.Add(issue);
        
        Console.WriteLine($"now : {dateTimerProvider.Now():s}");

        return new IssueCreated(issue.Id);
    }
}