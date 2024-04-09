﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator mediator;

        public SocialMediasController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Başarılı bir şekilde Categories eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await mediator.Send(command);
            return Ok("Başarılı bir şekilde Categories güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Başarılı bir şekilde Categories silindi");
        }
    }
}
