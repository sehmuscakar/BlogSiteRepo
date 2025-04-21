using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;

        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _aboutService.GetList();
            return View(listele);
        }
    }
}
