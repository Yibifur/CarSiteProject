using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.FeatureQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMediator mediator;

        public FeaturesController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Featurelist()
        {
            var values = await mediator.Send(new GetFeatureQuery());
            return Ok(values);  
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> FeatureId(int id)
        {
            var value = await mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("feature başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await mediator.Send(command);
            return Ok("feature başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFeature(int id)
        {
            await mediator.Send(new RemoveFeatureCommand(id));
            return Ok("feature başarıyla silindi");
        }
    }
}
