namespace HackingNews.Domain.Abstractions;

public interface IInMemHackingNewsService
{
    IList<int> HackingNewsIds { get; set; }
}