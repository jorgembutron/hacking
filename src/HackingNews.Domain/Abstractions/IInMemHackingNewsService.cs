namespace HackingNews.Domain.Abstractions;

public interface IInMemHackingNewsService
{
    IList<string> HackingNewsIds { get; set; }
}