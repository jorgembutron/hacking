namespace HackingNews.Domain.Abstractions;

public interface IHackerNewsClient<TReturn>
{
    Task<TReturn> ReturnHackingNewsAsync();
}