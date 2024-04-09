using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IRepository<Service> repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        

        public async Task Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.ServiceID);
            entity.ServiceID = request.ServiceID;
            entity.Description = request.Description;
            entity.Title = request.Title;
            entity.IconUrl = request.IconUrl;
            await repository.UpdateAsync(entity);
        }
    }
}
