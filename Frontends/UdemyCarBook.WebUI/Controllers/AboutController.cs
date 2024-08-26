using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IRepository<About> repository;
        public IActionResult Index()
        {
            return View();
        }
    }
}
