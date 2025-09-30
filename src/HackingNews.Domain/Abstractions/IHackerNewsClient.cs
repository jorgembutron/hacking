namespace HackingNews.Domain.Abstractions;

public interface IHackerNewsClient<TReturn>
{
    Task<IList<TReturn>> ReturnHackingNewsAsync(int numOfStories, IList<int> ids);
    Task<IList<string>> ReturnHackingNewsIdsAsync();
}