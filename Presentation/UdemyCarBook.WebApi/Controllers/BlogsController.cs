using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator mediator;

        public BlogsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetAllBlogsWithAuthorlist")]
        public async Task<IActionResult> GetAllBlogsWithAuthorlist()
        {
            var values = await mediator.Send(new GetAllBlogsWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet]
        public async Task<IActionResult> Bloglist()
        {
            var values = await mediator.Send(new GetBlogQuery());
            return Ok(values);
        }
        [HttpGet("TakeLast3Bloglist")]
        public async Task<IActionResult> TakeLast3Bloglist()
        {
            var values = await mediator.Send(new GetLast3BlogsWithAuthorQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BlogId(int id)
        {
            var value = await mediator.Send(new GetBlogByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await mediator.Send(command);
            return Ok("Blog başarıyla eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await mediator.Send(command);
            return Ok("Blog başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveBlog(int id)
        {
            await mediator.Send(new RemoveBlogCommand(id));
            return Ok("Blog başarıyla silindi");
        }




    }
}
