using HackingNews.Domain.Abstractions;
using HackingNews.Domain.CustomExceptions;
using Microsoft.Extensions.Logging;
using System.Net;

namespace HackingNews.Infrastructure.Resources;

public partial class HackerNewsClient : IExceptionManager<Exception>
{
    public void OnError(Exception ex)
    {
        logger.LogWarning(ex, ex.Message);

        if (ex is not HackingNewsProviderException pex)
            throw new Exception(ex.Message, ex);

        switch (pex.StatusCode)
        {
            case HttpStatusCode.BadRequest:
            case HttpStatusCode.UnprocessableEntity:
            case HttpStatusCode.Conflict:
            case HttpStatusCode.NotFound:
                throw new HackingNewsProviderException(pex.StatusCode, "GlobalLocation API returned an error");
            case HttpStatusCode.TooManyRequests:
                //throw new RateLimitException(gpe.Message);
            default:
                throw new Exception(pex.Message, pex);
        }

    }
}

