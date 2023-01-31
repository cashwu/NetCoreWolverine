using Microsoft.Extensions.Hosting;
using Oakton;
using Wolverine;
using Wolverine.Transports.Tcp;

return await Host.CreateDefaultBuilder(args)
                 .UseWolverine(opts =>
                 {
                     opts.ListenAtPort(5581);
                 })
                 .RunOaktonCommands(args);