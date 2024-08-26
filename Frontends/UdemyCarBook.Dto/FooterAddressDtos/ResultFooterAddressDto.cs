using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.FooterAddressDtos
{
    public class ResultFooterAddressDto
    {
        public int FooterAddressID { get; set; }
        public string Description { get; set; }
        public string address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
