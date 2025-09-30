namespace HackingNews.Infrastructure.Resources;

public abstract class ResourcesBase
{
    protected async Task<T> TryAsync<T, TException>(Action<TException> onErrorAsync, Func<Task<T>> func)
        where TException : Exception
    {
        try
        {
            return await func();
        }
        catch (TException e)
        {
            onErrorAsync?.Invoke(e);
        }

        return default;
    }
}