using System.Net;

namespace HackingNews.Domain.CustomExceptions;

public class HackingNewsProviderException(HttpStatusCode statusCode, string message) : Exception(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;

    public override string ToString() => StatusCode.ToString();
}