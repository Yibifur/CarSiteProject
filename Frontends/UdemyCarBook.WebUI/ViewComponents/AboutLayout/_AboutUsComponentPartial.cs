using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.AboutDtos;

namespace UdemyCarBook.WebUI.ViewComponents.AboutLayout
{
    public class _AboutUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;

        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task< IViewComponentResult> InvokeAsync() { 
            var client=httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44324/api/Abouts");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync(); 
                var value=JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(value);  
            }
            return View(); 
        
        }
    }
}
