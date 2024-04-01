using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.FooterAdressQueries;
using UdemyCarBook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressByIdResultHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> repository;

        public GetFooterAddressByIdResultHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await repository.GetByIDAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
            FooterAddressID = value.FooterAddressID,
            address=value.address,
            Description=value.Description,
            Email=value.Email,
            Phone=value.Phone

            };
        }
    }
}
