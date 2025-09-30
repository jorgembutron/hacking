using HackingNews.Domain.Abstractions;
using HackingNews.Domain.CustomExceptions;
using HackingNews.Infrastructure.Views;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Web;

namespace HackingNews.Infrastructure.Resources;

public partial class HackerNewsClient(
    HttpClient httpClient,
    ILogger<HackerNewsClient> logger) : ResourcesBase, IHackerNewsClient<HackingNewsView>
{
    //private readonly HttpClient _httpClient = httpClient;

    public async Task<HackingNewsView> ReturnHackingNewsAsync()
    {
        var requestUri = $"{_config.LocationUrl}{HttpUtility.UrlEncode(queryParameters)}";

        var request = new HttpRequestMessage(HttpMethod.Get, requestUri);

        var httpResponseMessage = await TryAsync<HttpResponseMessage, Exception>(OnError, () => SendAsync(request, CancellationToken.None));

        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync(CancellationToken.None);

        var response = JsonConvert.DeserializeObject<HackingNewsView>(responseContent);

        return response ?? new HackingNewsView();
    }


    private async Task<HttpResponseMessage> SendAsync(HttpRequestMessage webRequest, CancellationToken cancellationToken)
    {
        var httpResponseMessage = await httpClient.SendAsync(webRequest, cancellationToken);

        if (!httpResponseMessage.IsSuccessStatusCode)
            throw new HackingNewsProviderException(httpResponseMessage.StatusCode, await httpResponseMessage.Content.ReadAsStringAsync(cancellationToken));

        return httpResponseMessage;
    }
}