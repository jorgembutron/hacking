using System.Reflection;

namespace HackingNews.Api.v1.RequestDtos;

public class HackingNewsRequest
{
    public int? BestStories { get; set; }

    /// <summary>
    /// Custom binding for BestStories mapping https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-8.0
    /// At least one story is returned if the parameter is not provided or invalid
    /// </summary>
    /// <param name="context"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static ValueTask<HackingNewsRequest> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        int bestStories = int.TryParse(context.Request.Query["bestStories"], out int bs) ? bs : 1;

        var result = new HackingNewsRequest
        {
            BestStories = bestStories
        };
        return ValueTask.FromResult(result);
    }
}