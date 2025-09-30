namespace HackingNews.Api.v1
{
    public static partial class MinimalApis
    {
        public static void MinimalApiVerEndpoints(this WebApplication app)
        {
            app.MapGet("v1/version", async () => await Task.FromResult(Results.Ok("version 0.1.0")))
                .WithName("Get number version")
                .WithOpenApi();
        }
    }
}
