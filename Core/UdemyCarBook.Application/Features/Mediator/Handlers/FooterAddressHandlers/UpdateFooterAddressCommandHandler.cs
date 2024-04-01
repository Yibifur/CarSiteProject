using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FooterAdressCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler:IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> repository;
        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            this.repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
           var entity = await repository.GetByIDAsync(request.FooterAddressID);
            entity.FooterAddressID = request.FooterAddressID;
            entity.Phone = request.Phone;
            entity.Description = request.Description;
            entity.address = request.address;
            entity.Email = request.Email;
            await repository.UpdateAsync(entity); 
        }

      

        
    }
}
