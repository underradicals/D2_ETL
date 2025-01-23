// var pagedResult = new PaginatedResult(
//     20, 
//     -1, 
//     100, 
//     new Uri("http://localhost:8001"), 
//     new Uri("http://localhost:8001"),
//     new Uri("http://localhost:8001"),
//     new Uri("http://localhost:8001"));
//
// Console.WriteLine(pagedResult.PageSize);
// Console.WriteLine(pagedResult.PageNumber);
// Console.WriteLine(pagedResult.TotalRecords);
// Console.WriteLine(pagedResult.TotalPages);
// Console.WriteLine(pagedResult.FirstPage);

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureServices(options =>
{
    options.AddMediatR(o =>
    {
        o.RegisterServicesFromAssembly(typeof(Program).Assembly);
    });
});

var app = builder.Build();

// var mediator = app.Services.GetService<IMediator>();
// await mediator?.Publish(new Publisher())!;
    




