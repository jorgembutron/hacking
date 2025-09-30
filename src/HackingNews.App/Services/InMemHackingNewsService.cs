using HackingNews.Domain.Abstractions;
using HackingNews.Infrastructure.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace HackingNews.App.Services;

public class InMemHackingNewsService : IInMemHackingNewsService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public IList<int> HackingNewsIds { get; set; }

    public InMemHackingNewsService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _ = GetSustainabilityIndicators();
    }

    private async Task GetSustainabilityIndicators()
    {
        var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<HackerNewsClient>();

        HackingNewsIds = await context.ReturnHackingNewsIdsAsync();
    }
}