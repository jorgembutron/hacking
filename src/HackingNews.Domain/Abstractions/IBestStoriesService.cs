namespace HackingNews.Domain.Abstractions;

public interface IBestStoriesService
{
    IList<int> GetHackerNewsBestStories();
}