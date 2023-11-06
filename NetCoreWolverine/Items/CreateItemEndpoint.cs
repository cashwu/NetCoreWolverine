using System.Net;
using Microsoft.AspNetCore.Mvc;
using NetCoreWolverine.Entity;
using Wolverine.Attributes;
using Wolverine.Http;

namespace NetCoreWolverine.Items;

public static class CreateItemEndpoint
{
    public static async Task<ProblemDetails> Before(CreateItemCommand command,
                                                    ItemsDbContext db,
                                                    ILogger logger)
    {
        logger.LogInformation($"-- {nameof(CreateItemEndpoint)} {nameof(Before)} --");

        if (command.Id == Guid.Empty)
        {
            return new ProblemDetails
            {
                Detail = "id is required",
                Status = (int) HttpStatusCode.BadRequest
            };
        }

        var item = await db.Set<Item>().FindAsync(command.Id);

        if (item is null)
        {
            WolverineContinue.Result();
        }

        return item switch
        {
            null => WolverineContinue.NoProblems,
            _ => new ProblemDetails
            {
                Detail = "item already exists",
                Status = (int) HttpStatusCode.BadRequest
            }
        };
    }

    public static void After(ILogger logger)
    {
        logger.LogInformation($"-- {nameof(CreateItemEndpoint)} {nameof(After)}--");
    }

    [WolverinePost("/item")]
    [Transactional]
    [EmptyResponse]
    public static ItemCreated Post(CreateItemCommand command,
                                   ItemsDbContext db,
                                   ILogger logger)
    {
        logger.LogInformation($"-- {nameof(CreateItemEndpoint)} {nameof(Post)}--");

        var item = new Item
        {
            Id = command.Id,
            Name = command.Name
        };

        db.Items.Add(item);

        return new ItemCreated(item.Id);
    }
}