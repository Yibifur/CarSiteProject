using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IRepository<Feature> repository;

        public UpdateFeatureCommandHandler(IRepository<Feature> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.FeatureID);
            entity.FeatureID = request.FeatureID;
            entity.Name = request.Name;
            await repository.UpdateAsync(entity);
        }
    }
}
