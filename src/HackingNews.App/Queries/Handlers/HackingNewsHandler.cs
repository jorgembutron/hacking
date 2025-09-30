using HackingNews.App.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackingNews.App.Queries.Handlers
{
    public class HackingNewsHandler : IRequestHandler<HackingNewsQuery, HackingNewsResponse>
    {
        public Task<HackingNewsResponse> Handle(HackingNewsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
