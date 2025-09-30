namespace HackingNews.Domain.Abstractions;

public interface IProviderClientFactory<TReturn>
{
    IHackerNewsClient<TReturn>? Create();
}