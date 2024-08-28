using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandlers
{
    public class GetAuthorQueryHandler:IRequestHandler<GetAuthorQuery,List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _authorRepository;

        public GetAuthorQueryHandler(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }

        

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values=await _authorRepository.GetAllAsync();   
            return values.Select(x=>new GetAuthorQueryResult
            {
                AuthorID = x.AuthorID,
                Description = x.Description,
                ImageUrl = x.ImageUrl,
                Name = x.Name

            }).ToList();
        }
    }
}
