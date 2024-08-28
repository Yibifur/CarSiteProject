using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarQueryHandler
    {
        private readonly ICarRepository carRepository;

        public GetLast5CarQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public  List<GetLast5CarQueryResult> Handle()
        {
            var values =  carRepository.GetLast5CarWithBrand();
            return values.Select(x => new GetLast5CarQueryResult
            {
                CarID = x.CarID,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                Model = x.Model,
                CoverImageUrl = x.CoverImageUrl,
                Kilometer = x.Kilometer,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel,
                BigImageUrl = x.BigImageUrl,
                
                


            }).ToList();

        }
    }
}
