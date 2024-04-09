﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            this.repository = repository;
        }
        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await repository.GetByIDAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaID = entity.SocialMediaID,
               Url = entity.Url,
               Icon = entity.Icon,
               Name = entity.Name,

            };
        }
    }
}
