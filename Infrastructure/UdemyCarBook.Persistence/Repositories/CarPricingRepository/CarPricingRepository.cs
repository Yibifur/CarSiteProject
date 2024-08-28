using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarPricingRepository
{
    public class CarPricingRepository:ICarPricingRepository
    {
        private readonly CarBookContext context;

        public CarPricingRepository(CarBookContext context)
        {
            this.context = context;
        }

        

        public List<CarPricing> GetCarPricingWithCars(int pricingID)
        {
            var values = context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(x=>x.PricingID==pricingID).ToList();
            return values;
        }

        
    }
}
