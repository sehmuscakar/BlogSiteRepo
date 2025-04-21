using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _portfolioService.GetPortfolioList();
            return View(listele);
        }
    }
}
