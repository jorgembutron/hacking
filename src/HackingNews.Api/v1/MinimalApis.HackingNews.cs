using HackingNews.Api.Dtos;
using HackingNews.Api.Extensions;
using HackingNews.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackingNews.Api.v1;

public partial class MinimalApis
{
    public static void HackerNewsEndpoints(this WebApplication app)
    {
        app.MapGet("v1/hackernews/", async (HackingNewsRequest request, IMediator mediator) =>
        {
            var hackingNewsViewList = await mediator.Send(new HackingNewsQuery(request.NumOfStories));

            return ReturnHttpResponse(hackingNewsViewList.Map());

        }).Produces(200)
            .ProducesProblem(400)
            .WithOpenApi();
    }

    private static IResult ReturnHttpResponse<TDto>(TDto? dto) =>
        dto == null
            ? Results.NotFound(DataNotFoundResponse())
            : Results.Ok(dto);

    static ProblemDetails DataNotFoundResponse() => new()
    {
        Type = "DataNotFound",
        Detail = "Data not found with the selected criteria."
    };
}