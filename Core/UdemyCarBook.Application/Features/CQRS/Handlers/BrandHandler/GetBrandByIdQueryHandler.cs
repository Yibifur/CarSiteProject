﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.BrandQueries;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandler
{
    public class GetBrandByIdQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandByIdQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<GetBrandByIdQueryResult> Handle(GetBrandByIdQuery query)
        {
            var values = await _brandRepository.GetByIDAsync(query.Id);
            return new GetBrandByIdQueryResult
            {
            BrandID = values.BrandID,
            Cars = values.Cars,
            Name = values.Name
            };
        }
    }
}
