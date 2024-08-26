using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TesimonialHandlers
{
	public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
	{
		private readonly IRepository<Testimonial> repository;

		public CreateTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			this.repository = repository;
		}

		public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
		{
			await repository.CreateAsync(new Testimonial{
			Name = request.Name,
			Title = request.Title,
			Comment = request.Comment,
			ImageUrl = request.ImageUrl
			});

			
		}
	}
}
