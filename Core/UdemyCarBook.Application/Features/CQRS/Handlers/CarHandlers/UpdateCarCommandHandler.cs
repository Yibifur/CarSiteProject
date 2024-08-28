using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _carRepository;

        public UpdateCarCommandHandler(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(UpdateCarCommand command)
        {
            
            var entity = await _carRepository.GetByIDAsync(command.CarID);
            entity.CarID = command.CarID;
            entity.BrandID = command.BrandID;
            entity.Model = command.Model;
            entity.CoverImageUrl = command.Model;
            entity.Kilometer= command.Kilometer;
            entity.Transmission=command.Transmission;
            entity.Seat= command.Seat;
            entity.Luggage= command.Luggage;
            entity.Fuel= command.Fuel;
            entity.BigImageUrl= command.BigImageUrl;
            
            await _carRepository.UpdateAsync(entity);
        }
    }
}
