using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.ServiceDtos;

namespace UdemyCarBook.WebUI.ViewComponents.ServiceViewComponent
{
    public class _ServiceViewComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ServiceViewComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync() { 
                var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44324/api/Services");
            if (responseMessage.IsSuccessStatusCode) { 
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);

                return View(value);
            }
            return View();
        }
    }
}
