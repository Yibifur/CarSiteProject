using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using UdemyCarBook.Dto.FooterAddressDtos;


namespace UdemyCarBook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44324/api/FooterAddress");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultFooterAddressDto>>(jsondata);
                return View(model);
            }
            return View();
        }
    }
}
