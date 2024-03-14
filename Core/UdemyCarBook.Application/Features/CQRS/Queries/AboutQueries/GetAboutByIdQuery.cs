using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdQuery
    {
       
        public GetAboutByIdQuery(int Id)
        {
            this.Id = Id;
        } 
        public int Id { get; set; }
    }
}
