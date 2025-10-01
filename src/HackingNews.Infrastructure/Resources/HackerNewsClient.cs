using HackingNews.Domain.Abstractions;
using HackingNews.Domain.CustomExceptions;
using HackingNews.Infrastructure.Views;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HackingNews.Infrastructure.Resources;

public partial class HackerNewsClient(HttpClient httpClient, ILogger<HackerNewsClient> logger) : ResourcesBase, 
    IHackerNewsClient<HackingNewsView>
{
    
    /// <summary>
    /// Asynchronously retrieves a list of Hacker News item IDs from the service.
    /// </summary>
    /// <returns>A list of strings containing the IDs of Hacker News items. Returns an empty list if no items are found.</returns>
    public async Task<IList<int>> GetHackingNewsIdsAsync()
    {
        var requestUri = $"{"v0/beststories.json"}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var httpResponseMessage = await TryAsync<HttpResponseMessage, Exception>(OnError, () => SendAsync(request, CancellationToken.None));

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        var response = JsonConvert.DeserializeObject<IList<int>>(responseContent);

        return response ?? new List<int>();
    }

    /// <summary>
    /// ToDo: Add fault transient support
    /// ToDo: Store each error?
    /// ToDo: FallBack implementation?
    /// </summary>
    /// <param name="idList"></param>
    /// <returns></returns>
    public async Task<IList<HackingNewsView>> GetHackingNewsStoriesDetailAsync(IList<int> idList)
    {
        //Use configuration settings for the URL and parameters
        var requestUri = $"{"v0/item/"}";

        var result = idList.Select(id => GetDataAsync($"{requestUri}{id}.json"));

        return (await Task.WhenAll(result)).ToList();
    }

    /// <summary>
    /// Retrieves the details of a Hacking News story from the specified URI asynchronously.
    /// </summary>
    /// <param name="requestUri">The URI of the Hacking News story to retrieve. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="HackingNewsView"/>
    /// object with the story details. Returns a new <see cref="HackingNewsView"/> if the response content is null or
    /// cannot be deserialized.</returns>
    private async Task<HackingNewsView> GetDataAsync(string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var httpResponseMessage = await TryAsync<HttpResponseMessage, Exception>(OnError, () => SendAsync(request, CancellationToken.None));

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        var response = JsonConvert.DeserializeObject<HackingNewsView>(responseContent);

        return response ?? new HackingNewsView();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="webRequest"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="HackingNewsProviderException"></exception>
    private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage webRequest, CancellationToken cancellationToken)
    {
        var httpResponseMessage = await httpClient.SendAsync(webRequest, cancellationToken);

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new HackingNewsProviderException(httpResponseMessage.StatusCode, await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));

        return httpResponseMessage;
    }
}