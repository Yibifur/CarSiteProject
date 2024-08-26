using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BannersDtos;
using UdemyCarBook.Dto.TestimonialDtos;

namespace UdemyCarBook.WebUI.ViewComponents.TestimonialLayout
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _TestimonialComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
            var client=_httpClientFactory.CreateClient();
            var  responseMessage = await client.GetAsync("https://localhost:44324/api/Testimonial");
           if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata=await responseMessage.Content.ReadAsStringAsync();
                var model=JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsondata);
                return View(model);
            }
            return View();
        }
    }
}
