using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly IRepository<SocialMedia> repository;

        public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaID = x.SocialMediaID,
                Name = x.Name,
                Url = x.Url,
                Icon = x.Icon

            }).ToList();
        }
    }
}
