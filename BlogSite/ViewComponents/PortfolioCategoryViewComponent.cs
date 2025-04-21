using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class PortfolioCategoryViewComponent : ViewComponent
    {
        private readonly IPortfolioCategoryService _portfolioCategoryService;

        public PortfolioCategoryViewComponent(IPortfolioCategoryService portfolioCategoryService)
        {
            _portfolioCategoryService = portfolioCategoryService;
        }



        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _portfolioCategoryService.GetList();
            return View(listele);
        }
    }
}
