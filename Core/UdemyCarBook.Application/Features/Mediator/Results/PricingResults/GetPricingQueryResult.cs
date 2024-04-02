﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Results.PricingResults
{
    public class GetPricingQueryResult:IRequest
    {
        public int PricingID { get; set; }
        public string Name { get; set; }
    }
}