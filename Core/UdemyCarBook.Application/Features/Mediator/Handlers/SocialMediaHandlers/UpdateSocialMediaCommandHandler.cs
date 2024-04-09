using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> repository;

        public UpdateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }


        public async Task Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.SocialMediaID);
            entity.SocialMediaID = request.SocialMediaID;
            entity.Name = request.Name;
            entity.Url = request.Url;
            entity.Icon = request.Icon;
            await repository.UpdateAsync(entity);
        }
    }
}
