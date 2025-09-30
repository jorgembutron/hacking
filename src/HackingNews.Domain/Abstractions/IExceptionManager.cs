namespace HackingNews.Domain.Abstractions;

public interface IExceptionManager<in TException> where TException : Exception
{
    public void OnError(TException ex);
}