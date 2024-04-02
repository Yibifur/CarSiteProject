using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.PricingCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {

        private readonly IRepository<Pricing> repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.PricingID);
            entity.PricingID = request.PricingID;
            entity.Name = request.Name;
            repository.UpdateAsync(entity);
        }
    }
}
