using D2ETL.Api.Endpoints.AmmoTypes;
using D2ETL.Api.Endpoints.DamageTypes;

namespace D2ETL.Api;

public static class ApplicationApiRoutes
{
    public static WebApplication UseApplicationApi(this WebApplication app)
    {
        app.UseAllDamageTypeRoutes();
        app.UseByIdDamageTypeRoutes();
        app.UseAllAmmoTypeRoutes();
        app.UseByIdAmmoTypeRoutes();

        return app;
    }
}