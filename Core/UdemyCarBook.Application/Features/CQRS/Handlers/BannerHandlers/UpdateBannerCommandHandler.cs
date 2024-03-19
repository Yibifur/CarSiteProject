using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public  class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _bannerRepository;

        public UpdateBannerCommandHandler(IRepository<Banner> bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var entity = await _bannerRepository.GetByIDAsync(command.BannerID);
            entity.Title = command.Title;
            entity.Description = command.Description;
            entity.VideoDescription = command.VideoDescription;
            entity.VideoUrl = command.VideoUrl;
            await _bannerRepository.UpdateAsync(entity);
        }
    }
}
