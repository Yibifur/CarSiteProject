using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator mediator;

        public TestimonialController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Testimoniallist()
        {
            var values = await mediator.Send(new GetTestimonialQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> TestimonialId(int id)
        {
            var value = await mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Testimonial başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await mediator.Send(command);
            return Ok("Testimonial başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await mediator.Send(new RemoveTestimonialCommand(id));
            return Ok("Testimonial başarıyla silindi");
        }
    }
}
