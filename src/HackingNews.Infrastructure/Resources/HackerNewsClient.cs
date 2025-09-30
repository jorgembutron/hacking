using HackingNews.Domain.Abstractions;
using HackingNews.Domain.CustomExceptions;
using HackingNews.Infrastructure.Views;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web;

namespace HackingNews.Infrastructure.Resources;

public partial class HackerNewsClient(HttpClient httpClient, ILogger<HackerNewsClient> logger) : ResourcesBase, 
    IHackerNewsClient<HackingNewsView>
{
    
    /// <summary>
    /// Asynchronously retrieves a list of Hacker News item IDs from the service.
    /// </summary>
    /// <returns>A list of strings containing the IDs of Hacker News items. Returns an empty list if no items are found.</returns>
    public async Task<IList<string>> ReturnHackingNewsIdsAsync()
    {
        var requestUri = $"{"v0/"}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var httpResponseMessage = await TryAsync<HttpResponseMessage, Exception>(OnError, () => SendAsync(request, CancellationToken.None));

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        var response = JsonConvert.DeserializeObject<IList<string>>(responseContent);

        return response ?? new List<string>();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="numOfStories"></param>
    /// <param name="idList"></param>
    /// <returns></returns>
    public async Task<HackingNewsView> ReturnHackingNewsAsync(int numOfStories, IList<int> idList)
    {
        //Use configuration for the URL and parameters
        var requestUri = $"{"v0/item/"}";

        var result = idList.Select(id => GeHackingNewsStoriesDetailAsync($"{requestUri}{id}.json")).ToList();

        var stories = await Task.WhenAll(result);


        return stories ?? new HackingNewsView();
    }

    private async Task<HackingNewsView?> GeHackingNewsStoriesDetailAsync(string requestUri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var httpResponseMessage = await TryAsync<HttpResponseMessage, Exception>(OnError, () => SendAsync(request, CancellationToken.None));

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        var response = JsonConvert.DeserializeObject<HackingNewsView>(responseContent);

        return response;
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