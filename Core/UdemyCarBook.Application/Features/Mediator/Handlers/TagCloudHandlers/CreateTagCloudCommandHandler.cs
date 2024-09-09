﻿using MediatR;
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
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            this.repository = repository;
        }

        async Task IRequestHandler<CreateTagCloudCommand>.Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
             await repository.CreateAsync(new TagCloud
            {
                BlogId = request.BlogId,
                Title = request.Title

            });
            
        }
    }
}
