using HackingNews.Api.Dtos;
using HackingNews.Infrastructure.Views;

namespace HackingNews.Api.Extensions;

public static class MapExtensions
{
    public static IList<HackingNewsResponse> Map(this IList<HackingNewsView> view) => 
        view.Select(MapTo).ToList();

    public static HackingNewsResponse MapTo(this HackingNewsView view)
    {
        return new HackingNewsResponse
        {
            Title = view.Title,
            Uri = view.Url,
            PostedBy = view.By,
            Time = view.Time,
            Score = view.Score,
            CommentCount = view.Descendants
        };
    }
}