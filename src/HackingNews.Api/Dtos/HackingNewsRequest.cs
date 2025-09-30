using System.Reflection;

namespace HackingNews.Api.Dtos;

public class HackingNewsRequest
{
    public int NumOfStories { get; set; }

    /// <summary>
    /// Custom model binder to bind and validate the query parameter "numofstories"
    /// </summary>
    /// <param name="context"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static async ValueTask<HackingNewsRequest?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        if (!int.TryParse(context.Request.Query["numofstories"], out int bestStories))
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.CompleteAsync();
            return null;
        }

        var result = new HackingNewsRequest
        {
            NumOfStories = bestStories
        };
        return await ValueTask.FromResult(result);
    }
}