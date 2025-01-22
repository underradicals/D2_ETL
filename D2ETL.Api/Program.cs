using D2ETL.Api;

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

