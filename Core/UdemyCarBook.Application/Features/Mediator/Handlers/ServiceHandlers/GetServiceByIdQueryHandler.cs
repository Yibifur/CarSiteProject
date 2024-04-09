﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarBook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IRepository<Service> repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }
        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var entity=await repository.GetByIDAsync(request.Id);
            return new GetServiceByIdQueryResult
            {
                ServiceID = entity.ServiceID,
                Description = entity.Description,
                IconUrl = entity.IconUrl,
                Title = entity.Title

            };
        }
    }
}
