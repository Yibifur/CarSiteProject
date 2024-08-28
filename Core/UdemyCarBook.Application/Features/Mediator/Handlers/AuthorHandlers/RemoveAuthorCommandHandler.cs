using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.AuthorCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class RemoveAuthorCommandHandler
    {
        private readonly IRepository<Author> _AuthorRepository;

        public RemoveAuthorCommandHandler(IRepository<Author> AuthorRepository)
        {
            _AuthorRepository = AuthorRepository;
        }
        public async Task Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _AuthorRepository.GetByIDAsync(request.Id);
            await _AuthorRepository.RemoveAsync(entity);
        }
    }
}
