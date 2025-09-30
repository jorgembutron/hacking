using HackingNews.App.Dtos;
using HackingNews.Domain.Abstractions;
using HackingNews.Infrastructure.Views;
using MediatR;

namespace HackingNews.App.Queries.Handlers
{
    public class HackingNewsHandler : IRequestHandler<HackingNewsQuery, HackingNewsResponse>
    {
        private readonly IInMemHackingNewsService _inMemHackingNewsService;
        private readonly IHackerNewsClient<HackingNewsView> _hackerNewsClient;


        public HackingNewsHandler(IInMemHackingNewsService inMemHackingNewsService,
            IHackerNewsClient<HackingNewsView> hackerNewsClient)
        {
            _inMemHackingNewsService = inMemHackingNewsService;
            _hackerNewsClient = hackerNewsClient;
        }

        public Task<HackingNewsResponse> Handle(HackingNewsQuery request, CancellationToken cancellationToken)
        {
            var ids = _inMemHackingNewsService.HackingNewsIds;

            var view = _hackerNewsClient.ReturnHackingNewsAsync(request.bestStories, ids));
        }
    }
}
