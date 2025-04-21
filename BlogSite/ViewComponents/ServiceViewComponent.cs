using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public ServiceViewComponent(IServiceService serviceService)
        {
            this._serviceService = serviceService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _serviceService.GetList();
            return View(listele);
        }
    }
}
