using System.Net;

namespace HackingNews.Domain.CustomExceptions;

public class HackingNewsProviderException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public HackingNewsProviderException(HttpStatusCode statusCode, string readAsStringAsync)
    {
        StatusCode = statusCode;
    }

    public override string ToString() => StatusCode.ToString();
}