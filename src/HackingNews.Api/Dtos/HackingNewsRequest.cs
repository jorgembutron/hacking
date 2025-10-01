using System.Reflection;

namespace HackingNews.Api.Dtos;

public class HackingNewsRequest
{
    private const string NumOfStoriesName = "numofstories";
    public int NumOfStories { get; set; }

    /// <summary>
    /// Custom model binder to bind and validate the query parameter "numofstories"
    /// </summary>
    /// <param name="context"></param>
    /// <param name="parameter"></param>
    /// <returns></returns>
    public static async ValueTask<HackingNewsRequest?> BindAsync(HttpContext context, ParameterInfo parameter)
    {
        if (!int.TryParse(context.Request.Query[NumOfStoriesName], out int numOfStories) || numOfStories < 1)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsJsonAsync(new
            {
                error = $"Invalid or missing {NumOfStoriesName} query parameter. Must be greater than 1."
            });

            await context.Response.CompleteAsync();
            return null;
        }

        var result = new HackingNewsRequest
        {
            NumOfStories = numOfStories
        };
        return await ValueTask.FromResult(result);
    }
}