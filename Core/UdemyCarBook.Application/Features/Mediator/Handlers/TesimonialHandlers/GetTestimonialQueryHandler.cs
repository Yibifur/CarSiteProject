using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TesimonialHandlers
{
	public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
	{
		private readonly IRepository<Testimonial> repository;
public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
		{
			this.repository = repository;
		}

		public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
		{
			var entities = await repository.GetAllAsync();
			return entities.Select(x=>new GetTestimonialQueryResult
			{
				Name = x.Name,
				Comment = x.Comment,
				ImageUrl = x.ImageUrl,
				Title = x.Title
			}).ToList();
			
			
		}
	}
}
