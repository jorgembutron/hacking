using HackingNews.Infrastructure.Views;
using MediatR;

namespace HackingNews.App.Queries;

public record HackingNewsQuery(int NumOfStories) : IRequest<IList<HackingNewsView>>;