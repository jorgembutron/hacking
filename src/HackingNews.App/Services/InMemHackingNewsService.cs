using HackingNews.Domain.Abstractions;
using HackingNews.Infrastructure.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace HackingNews.App.Services;

/// <summary>
/// This only executes the first time the service is constructed,
/// set as a singleton in the DI container
/// Provides an in-memory implementation of the Hacker News service that retrieves and stores a list of Hacker News
/// story IDs.
/// </summary>
/// <remarks>This service initializes its list of Hacker News story IDs when constructed and stores them in memory
/// for quick access. It is intended for scenarios where repeated access to the list of story IDs is required without
/// querying the external source each time.</remarks>
public class InMemHackingNewsService : IInMemHackingNewsService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public IList<int> HackingNewsIds { get; set; }

    public InMemHackingNewsService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        GetHackerNewsBestStories();
    }

    private void GetHackerNewsBestStories()
    {
        var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HackerNewsClient>();

        HackingNewsIds = context.GetHackingNewsIdsAsync().Result;
    }
}