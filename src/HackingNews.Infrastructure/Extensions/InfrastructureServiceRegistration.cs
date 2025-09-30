using HackingNews.Infrastructure.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using System.Net.Mime;

namespace HackingNews.Infrastructure.Extensions;

public static class InfrastructureServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        // Add infrastructure services here
        serviceCollection.AddHttpClient<HackerNewsClient>(ConfigureHackingNewsHttpClient);
    }

    private static void ConfigureHackingNewsHttpClient(HttpClient client)
    {
        client.BaseAddress = new Uri("https://hacker-news.firebaseio.com/");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
    }
}

