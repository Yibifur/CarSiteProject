using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.ContactResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task<List<GetContactQueryResult>> Handle()
        {
            var entities=await repository.GetAllAsync();
            return entities.Select(x => new GetContactQueryResult
            {
                ContactID = x.ContactID,
                Name = x.Name,
                Subject = x.Subject,
                Mail = x.Mail,
                SendDate = x.SendDate,
                Message = x.Message


            }).ToList();



        }
    }
}
