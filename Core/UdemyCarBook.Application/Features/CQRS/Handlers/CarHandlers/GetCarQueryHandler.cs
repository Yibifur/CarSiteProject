using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _carRepository;

        public GetCarQueryHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values=await _carRepository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
                 CarID =x.CarID,
                 BrandID =x.BrandID,
                 Brand =x.Brand,
                 Model =x.Model,
                 CoverImageUrl=x.CoverImageUrl,
                 Kilometer =x.Kilometer,
                 Transmission =x.Transmission,
                Seat =x.Seat,
                Luggage =x.Luggage,
                 Fuel =x.Fuel,
                 BigImageUrl =x.BigImageUrl,
                    CarFeatures =x.CarFeatures,
                    CarDescriptions =x.CarDescriptions,
                        CarPricings =x.CarPricings 
       
    }).ToList();
            
        }
    }
}
