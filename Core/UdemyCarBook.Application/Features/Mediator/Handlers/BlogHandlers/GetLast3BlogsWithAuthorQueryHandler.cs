using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorQuery, List<GetLast3BlogsWithAuthorQueryResult>>
    {
        private readonly IBlogRepository blogRepository;

        public GetLast3BlogsWithAuthorQueryHandler(IBlogRepository blogRepository)
        {
            this.blogRepository = blogRepository;
        }

        public async Task<List<GetLast3BlogsWithAuthorQueryResult>> Handle(GetLast3BlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values =  blogRepository.GetLast3BlogsWithAuthorAsync();
            return values.Select(x => new GetLast3BlogsWithAuthorQueryResult
            {
                Name = x.Author.Name,
                BlogID = x.BlogID,
                Title = x.Title,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                CreationDate = x.CreationDate,
                CoverImageUrl = x.CoverImageUrl,
                Description = x.Description
            }).ToList();
        }
    }
}
