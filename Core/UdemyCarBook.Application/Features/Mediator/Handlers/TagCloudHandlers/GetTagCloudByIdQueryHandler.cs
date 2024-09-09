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
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }

        

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                BlogId = entity.BlogId,
                TagCloudId = entity.TagCloudId,
                Title = entity.Title
            };

           
        }
    }
}
