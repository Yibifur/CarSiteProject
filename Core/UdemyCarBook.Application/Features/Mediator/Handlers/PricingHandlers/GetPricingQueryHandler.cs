using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.PricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.PricingResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery,List<GetPricingQueryResult>>
    {
        private readonly IRepository<Pricing> repository;

        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }

        

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(x => new GetPricingQueryResult
            {
Name = x.Name,
PricingID= x.PricingID
            }).ToList();
        }
    }
}
