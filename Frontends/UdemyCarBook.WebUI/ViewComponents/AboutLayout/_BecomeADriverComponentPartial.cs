using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.AboutLayout
{
	public class _BecomeADriverComponentPartial:ViewComponent
	{
		public  async Task<IViewComponentResult> InvokeAsync()
		{
			return View();
		}
	}
}
