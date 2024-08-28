using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;
using UdemyCarBook.Application.Features.Mediator.Results.CarPricingResults;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarsQueryHandler:IRequestHandler<GetCarPricingWithCarsQuery,List<GetCarPricingWithCarsQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarsQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarsQueryResult>> Handle(GetCarPricingWithCarsQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarPricingWithCars(2);
            return values.Select(x => new GetCarPricingWithCarsQueryResult
            {
                CarPricingID = x.CarPricingID,
                Model=x.Car.Model,
                CoverImageUrl=x.Car.CoverImageUrl,
                BrandName=x.Car.Brand.Name,
                PricingAmount=x.Amount,
                PricingTitle=x.Pricing.Name
                }).ToList();
        }
    }
}
                
                
               
                
               
                
                
                

    
