using System.Net;

namespace HackingNews.App.CustomExceptions;

public class HackingNewsProviderException : Exception
{
    public HackingNewsProviderException(HttpStatusCode statusCode, string readAsStringAsync)
    {
        throw new NotImplementedException();
    }
}