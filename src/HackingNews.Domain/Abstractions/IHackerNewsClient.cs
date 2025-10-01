namespace HackingNews.Domain.Abstractions;

public interface IHackerNewsClient<TReturn>
{
    Task<IList<TReturn>> GetHackingNewsStoriesDetailAsync(IList<int> ids);
    Task<IList<int>> GetHackingNewsIdsAsync();
}