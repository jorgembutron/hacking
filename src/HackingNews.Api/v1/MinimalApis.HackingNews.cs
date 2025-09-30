using HackingNews.Api.v1.RequestDtos;
using HackingNews.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HackingNews.Api.v1;

public partial class MinimalApis
{
    public static void MinimalApiGhgProtocolEndPoints(this WebApplication app)
    {
        app.MapGet("v1/repairs/ghgprotocol/status", async (HackingNewsRequest request, IMediator mediator) =>
                {
                    var calculationStatus =
                        await mediator.Send(new HackingNewsQuery(request.BestStories));

                    return ReturnHttpResponse(calculationStatus);

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