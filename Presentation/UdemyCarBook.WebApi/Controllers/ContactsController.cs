using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryhandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactsController(CreateContactCommandHandler createContactCommandHandler,
            GetContactByIdQueryHandler getContactByIdQueryHandler,
            GetContactQueryHandler getContactQueryhandler, RemoveContactCommandHandler removeContactCommandHandler,
            UpdateContactCommandHandler updateContactCommandHandler)
        {
            _createContactCommandHandler = createContactCommandHandler;
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryhandler = getContactQueryhandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryhandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Başarılı bir şekilde Categories eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Başarılı bir şekilde Categories güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommand(id));
            return Ok("Başarılı bir şekilde Categories silindi");
        }
    }
}
