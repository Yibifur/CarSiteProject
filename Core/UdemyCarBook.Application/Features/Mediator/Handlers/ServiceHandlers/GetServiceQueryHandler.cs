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
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var entities = await repository.GetAllAsync();
            return entities.Select(x => new GetServiceQueryResult
            {
            ServiceID = x.ServiceID,
            Title = x.Title,
            Description = x.Description,
            IconUrl = x.IconUrl

            }).ToList();
        }
    }
}
