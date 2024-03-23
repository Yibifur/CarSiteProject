﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarBook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries;
using UdemyCarBook.Application.Features.CQRS.Queries.CarQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly GetCarByIdQueryHandler getCarByIdQueryHandler;
        private readonly GetCarQueryHandler getCarQueryHandler;
        private readonly RemoveCarCommandHandler removeCarCommandHandler;
        private readonly CreateCarCommandHandler createCarCommandHandler;
        private readonly UpdateCarCommandHandler updateCarCommandHandler;

        public CarsController(GetCarByIdQueryHandler getCarByIdQueryHandler, GetCarQueryHandler getCarQueryHandler, RemoveCarCommandHandler removeCarCommandHandler, CreateCarCommandHandler createCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler)
        {
            this.getCarByIdQueryHandler = getCarByIdQueryHandler;
            this.getCarQueryHandler = getCarQueryHandler;
            this.removeCarCommandHandler = removeCarCommandHandler;
            this.createCarCommandHandler = createCarCommandHandler;
            this.updateCarCommandHandler = updateCarCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var values = await getCarQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCar(int id)
        {
            var value = await getCarByIdQueryHandler.Handle(new GetCarByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await createCarCommandHandler.Handle(command);
            return Ok("Başarılı bir şekilde About eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await updateCarCommandHandler.Handle(command);
            return Ok("Başarılı bir şekilde About güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCar(int id)
        {
            await removeCarCommandHandler.Handle(new RemoveCarCommand(id));
            return Ok("Başarılı bir şekilde About silindi");
        }
    }
}
