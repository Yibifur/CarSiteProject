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

        
        //Include 1.seviye ilişkileri beraber getirir mesela Car entitysi ile Brand Entitysi
        //ThenInclude ise 2.seviye ve daha alt ilişkileri beraber getirir mesela Car entitysi Car pricing ile 1.seviye ilşkili CarPricing de Pricing ile ilşikili bu yüzden car ile Pricing arasında 2.seviye ilişki var ve ThenInclude kullanılmalı
        public List<Car> GetCarWithBrand()
        {
            var values=carBookContext.Cars.Include(x => x.Brand).ToList();
            return  values;
        }

        public List<Car> GetLast5CarWithBrand()
        {
           var values=carBookContext.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }
    }
}
