﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.FooterAdressCommands
{
    public class CreateFooterAddressCommand:IRequest
    {
        public string Description { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
