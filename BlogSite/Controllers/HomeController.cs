using BlogSite.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSite.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public HomeController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Portfolio(int id)
        {

            var resultDataId = _portfolioService.GetByIDDto(id);
            return View(resultDataId);
        }

    }
}
