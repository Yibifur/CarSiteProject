using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.CarPricingQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPricingsController : ControllerBase
    {
        private readonly IMediator mediator;

        public CarPricingsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetCarPricingWithCars")]
        public async Task<IActionResult> GetCarPricingWithCarslist()
        {
            var values = await mediator.Send(new GetCarPricingWithCarsQuery());
            return Ok(values);
        }
    }
}
