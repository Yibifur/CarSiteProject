using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;


namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagCloudsController : ControllerBase
    {
        private readonly IMediator mediator;

        public TagCloudsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> TagCloudlist()
        {
            var values = await mediator.Send(new GetTagCloudsQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TagCloudId(int id)
        {
            var value = await mediator.Send(new GetTagCloudByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTagCloud(CreateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTagCloud(UpdateTagCloudCommand command)
        {
            await mediator.Send(command);
            return Ok("TagCloud başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTagCloud(int id)
        {
            await mediator.Send(new RemoveTagCloudCommand(id));
            return Ok("TagCloud başarıyla silindi");
        }
    }
}
