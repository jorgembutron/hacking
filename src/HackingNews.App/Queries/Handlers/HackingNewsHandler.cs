using HackingNews.Domain.Abstractions;
using HackingNews.Infrastructure.Views;
using MediatR;

namespace HackingNews.App.Queries.Handlers;

public class HackingNewsHandler : IRequestHandler<HackingNewsQuery, IList<HackingNewsView>>
{
    private readonly IBestStoriesService _bestStoriesService;
    private readonly IProviderClientFactory<HackingNewsView> _providerClient;

    public HackingNewsHandler(
        IBestStoriesService bestStoriesService,
        IProviderClientFactory<HackingNewsView> providerClient)
    {
        _bestStoriesService = bestStoriesService;
        _providerClient = providerClient;
    }

    public async Task<IList<HackingNewsView>> Handle(HackingNewsQuery request, CancellationToken cancellationToken)
    {
        var listOfIds = _bestStoriesService.GetHackerNewsBestStories();

        var client = _providerClient.Create();

        if (client != null)
        {
            var stories = await client.GetHackingNewsStoriesDetailAsync(listOfIds);

            var topStories = stories
                .OrderByDescending(s => s.Score)
                .Take(request.NumOfStories)
                .ToList();

            return topStories;
        }

        throw new Exception("Unable to resolve the provider.");
    }
}