using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            this.repository = repository;
        }
        public async Task Handle(UpdateContactCommand command)
        {
            var entity = await repository.GetByIDAsync(command.ContactID);
            entity.ContactID = command.ContactID;
            entity.Subject = command.Subject;
            entity.Message = command.Message;
            entity.SendDate = command.SendDate;
            entity.Name = command.Name; 
            entity.Mail = command.Mail;
            await repository.UpdateAsync(entity);
        }
    }
}
