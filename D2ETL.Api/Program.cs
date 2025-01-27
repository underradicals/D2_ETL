using D2ETL.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

try
{
    var builder = D2ETLApplication.CreateBuilder(args);

    var app = D2ETLApplication.Build(builder);
    
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

