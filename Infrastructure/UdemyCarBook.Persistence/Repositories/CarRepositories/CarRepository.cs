using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarRepository: ICarRepository
    {
        private readonly CarBookContext carBookContext;

        public CarRepository(CarBookContext carBookContext)
        {
            this.carBookContext = carBookContext;
        }

        

       public List<Car> GetCarWithBrand()
        {
            var values=carBookContext.Cars.Include(x => x.Brand).ToList();
            return  values;
        }

        public List<Car> GetLastNumCarWithBrand(int num)
        {
           var values=carBookContext.Cars.OrderByDescending(x=>x.CarID).Take(num).ToList();
            return values;
        }
    }
}
