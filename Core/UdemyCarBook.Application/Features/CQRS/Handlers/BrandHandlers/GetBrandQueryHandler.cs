using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandler
{
    public class GetBrandQueryHandler
    {
        private readonly IRepository<Brand> _brandRepository;

        public GetBrandQueryHandler(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public async Task<List<GetBrandQueryResult>> Handle()
        {
            var values=await _brandRepository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResult{
                BrandID = x.BrandID,
                Cars = x.Cars,
                Name = x.Name
            }).ToList();
        }
    }
}
