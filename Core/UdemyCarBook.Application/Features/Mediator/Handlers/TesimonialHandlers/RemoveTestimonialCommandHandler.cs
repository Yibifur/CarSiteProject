﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TesimonialHandlers
{
	public class RemoveTestimonialCommandHandler : IRequestHandler<RemoveTestimonialCommand>
	{
		private readonly IRepository<Testimonial> _repository;

		public RemoveTestimonialCommandHandler(IRepository<Testimonial> repository)
		{
			_repository = repository;
		}

		public async Task Handle(RemoveTestimonialCommand request, CancellationToken cancellationToken)
		{
			var entity=await _repository.GetByIDAsync(request.Id);
			await _repository.RemoveAsync(entity);
		}
	}
}
