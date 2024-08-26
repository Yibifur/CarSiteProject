using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.ContactDtos;

namespace UdemyCarBook.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto model)
        {
            
            var client=_httpClientFactory.CreateClient();
            model.SendDate = DateTime.Now;
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent stringContent =new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44324/api/Contacts", stringContent);
            if (responseMessage.IsSuccessStatusCode) { 
            return RedirectToAction("Index");
            
            }
            return View();
        }
    }
}
