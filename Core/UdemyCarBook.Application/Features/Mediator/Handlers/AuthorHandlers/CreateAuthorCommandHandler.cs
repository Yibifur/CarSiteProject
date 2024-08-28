using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {

        private readonly IRepository<Author> _authorRepository;

        public CreateAuthorCommandHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }



        public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _authorRepository.CreateAsync(new Author
            {
                Description=request.Description,
                ImageUrl=request.ImageUrl,
                Name=request.Name
            });
        }
    }
}