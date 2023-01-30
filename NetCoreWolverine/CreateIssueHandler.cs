public class CreateIssueHandler
{
    public IssueCreated Handle(CreateIssue command)
    {
        var issue = new Issue
        {
            Id = command.Id,
            Title = command.Title,
            Desc = command.Desc 
        };
        
        Store.Issues.Add(issue);

        return new IssueCreated(issue.Id);
    }
}