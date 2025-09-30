using HackingNews.App.Dtos;
using MediatR;

namespace HackingNews.App.Queries;

public record HackingNewsQuery(int bestStories) : IRequest<HackingNewsResponse>;