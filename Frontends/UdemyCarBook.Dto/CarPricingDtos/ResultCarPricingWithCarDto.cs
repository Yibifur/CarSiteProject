using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dto.CarPricingDtos
{
    public class ResultCarPricingWithCarDto
    {
        public int CarPricingID { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BrandName { get; set; }
        public decimal PricingAmount { get; set; }
        public string PricingTitle { get; set; }
    }
}
