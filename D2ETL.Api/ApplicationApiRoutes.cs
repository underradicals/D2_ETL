using D2ETL.Api.Endpoints.AmmoTypes;
using D2ETL.Api.Endpoints.DamageTypes;
using D2ETL.Api.Endpoints.LoreTypes;

namespace D2ETL.Api;

public static class ApplicationApiRoutes
{
    public static WebApplication UseApplicationApi(this WebApplication app)
    {
        app.UseAllDamageTypeRoutes();
        app.UseByIdDamageTypeRoutes();
        app.UseAllAmmoTypeRoutes();
        app.UseByIdAmmoTypeRoutes();
        app.UseGetPagedLoreType();
        app.UseGetByIdLoreType();

        return app;
    }
}