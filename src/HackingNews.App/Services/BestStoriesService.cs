using HackingNews.Domain.Abstractions;

namespace HackingNews.App.Services;

public class BestStoriesService : IBestStoriesService
{
    private readonly IInMemHackingNewsService _inMemHackingNewsService;

    public BestStoriesService(IInMemHackingNewsService inMemHackingNewsService)
    {
        _inMemHackingNewsService = inMemHackingNewsService;
    }

    public IList<int> GetHackerNewsBestStories() => _inMemHackingNewsService.HackingNewsIds;
}