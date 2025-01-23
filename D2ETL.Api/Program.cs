using D2ETL.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

try
{
    var builder = D2ETLApplication.CreateBuilder(args);

    var app = D2ETLApplication.Build(builder);

    app.MapGet("/test", (HttpContext context, [FromQuery]int pageSize, [FromQuery]int pageNumber) =>
    {
        var baseUrl = new Uri(context.Request.Scheme + "://" + context.Request.Host.Value + context.Request.PathBase.Value);
        var newUrl = QueryHelpers.AddQueryString(baseUrl.ToString(), new Dictionary<string, string?>
        {
            ["pageSize"] = $"{pageSize}",
            ["pageNumber"] = $"{pageNumber}",
        });
        return newUrl;
    });
    
    await app.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Done");
}

