using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarBook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }
        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery)
        {
            var values = await repository.GetByIDAsync(getCarByIdQuery.Id);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                //BrandName = values.Brand.Name,
                Model = values.Model,
                CoverImageUrl = values.CoverImageUrl,
                Kilometer=values.Kilometer,
                Transmission=values.Transmission,
                Seat=values.Seat,
                Luggage=values.Luggage,
                Fuel=values.Fuel,
                BigImageUrl=values.BigImageUrl,
                

            };

        }
    }
}
