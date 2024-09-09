using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogViewSidebarSearchBoxComponentPartial:ViewComponent
    {
        public async Task< IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
