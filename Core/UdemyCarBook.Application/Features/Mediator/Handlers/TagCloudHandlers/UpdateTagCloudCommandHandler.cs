using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }

        async Task IRequestHandler<UpdateTagCloudCommand>.Handle(UpdateTagCloudCommand request, CancellationToken cancellationToken)
        {
            var entity=await repository.GetByIDAsync(request.TagCloudId);
            entity.TagCloudId = request.TagCloudId;
            entity.Title = request.Title;   
            entity.BlogId = request.BlogId;
            await repository.UpdateAsync(entity);
        }
    }
}
