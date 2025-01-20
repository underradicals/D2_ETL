using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Playground.TestMediatR;


var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(options =>
{
    options.AddMediatR(o =>
    {
        o.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
});

var app = builder.Build();

var mediator = app.Services.GetService<IMediator>();
await mediator?.Publish(new Publisher())!;
    




