using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.SocialMediaQueries;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TesimonialHandlers
{
	public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
	{
		private readonly IRepository<Testimonial> repository;

		public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
		{
			this.repository = repository;
		}

		public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
		{
			var value=await repository.GetByIDAsync(request.Id);
			return new GetTestimonialByIdQueryResult
			{
				Comment = value.Comment,
				Name = value.Name,
				Title = value.Title,
				ImageUrl = value.ImageUrl
			};
		}
	}
}
