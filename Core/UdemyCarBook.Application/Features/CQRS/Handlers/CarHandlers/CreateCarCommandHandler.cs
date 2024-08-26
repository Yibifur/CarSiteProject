using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _carRepository;

        public CreateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(CreateCarCommand command)
        {
            await _carRepository.CreateAsync(new Car
            {
                
               
                BrandID = command.BrandID,
                BrandName = command.BrandName,
                Model = command.Model,
                CoverImageUrl = command.CoverImageUrl,
                Kilometer = command.Kilometer,
                Transmission = command.Transmission,
                Seat = command.Seat,
                Luggage = command.Luggage,
                Fuel = command.Fuel,
                BigImageUrl = command.BigImageUrl,
               
            });
        }
    }
}
