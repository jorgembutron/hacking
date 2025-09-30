using HackingNews.Domain.Abstractions;
using HackingNews.Infrastructure.Resources;
using HackingNews.Infrastructure.Views;
using Microsoft.Extensions.DependencyInjection;

namespace HackingNews.Infrastructure.Factories;

public class ProviderClientFactory : IProviderClientFactory<HackingNewsView>
{
    private readonly IServiceProvider _serviceProvider;

    public ProviderClientFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// ToDo: Create logic if more providers are added in the future
    /// </summary>
    /// <returns></returns>
    public IHackerNewsClient<HackingNewsView>? Create()
    {
        return _serviceProvider.GetService<HackerNewsClient>();
    }
}