using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var entity = await repository.GetByIDAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = entity.ContactID,
                Name = entity.Name,
                Subject = entity.Subject,
                Mail= entity.Mail,
                SendDate = entity.SendDate,
                Message = entity.Message
            };


        }
    }
}
