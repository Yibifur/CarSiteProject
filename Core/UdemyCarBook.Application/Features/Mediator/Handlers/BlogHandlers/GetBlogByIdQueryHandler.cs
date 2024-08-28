﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            this.repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await repository.GetByIDAsync(request.Id);
            return new GetBlogByIdQueryResult
            { 
                BlogID = value.BlogID,
                AuthorID = value.AuthorID,
               
                CategoryID = value.CategoryID,
                CoverImageUrl = value.CoverImageUrl,
                CreationDate = value.CreationDate,
                Title = value.Title,
                Description = value.Description
            };
        }
    }
}
