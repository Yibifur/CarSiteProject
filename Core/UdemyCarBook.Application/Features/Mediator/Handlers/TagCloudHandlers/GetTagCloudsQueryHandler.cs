using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudsQueryHandler : IRequestHandler<GetTagCloudsQuery, List<GetTagCloudsQueryResult>>
    {
        private readonly IRepository<TagCloud> repository;

        public GetTagCloudsQueryHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetTagCloudsQueryResult>> Handle(GetTagCloudsQuery request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetAllAsync();
            
            return entities.Select(x=> new GetTagCloudsQueryResult
            {
                Title = x.Title,
                TagCloudId = x.TagCloudId,
                BlogId=x.BlogId
            }).ToList();
        }
    }
}
