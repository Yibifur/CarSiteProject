using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _blogRepository;

        public UpdateBlogCommandHandler(IRepository<Blog> blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var value=await _blogRepository.GetByIDAsync(request.BlogID);
            value.Title = request.Title;
            value.CreationDate = request.CreationDate;  
            value.BlogID = request.BlogID;
            value.AuthorID = request.AuthorID;  
            value.CoverImageUrl = request.CoverImageUrl;    
            value.CategoryID = request.CategoryID;  
            value.Description = request.Description;
            await _blogRepository.UpdateAsync(value);
        }
    }
}
