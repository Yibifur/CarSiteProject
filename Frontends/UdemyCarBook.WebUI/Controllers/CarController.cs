using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json;
using UdemyCarBook.Dto.CarDtos;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44324/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsondata);
                return View(model);
            }
            return View();
        }
    }
}
