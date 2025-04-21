using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IPortfolioCategoryService _portfolioCategoryService;

        public PortfolioController(IPortfolioService portfolioService, IPortfolioCategoryService portfolioCategoryService)
        {
            _portfolioService = portfolioService;
            _portfolioCategoryService = portfolioCategoryService;
        }

        public IActionResult Index()
        {
            var values = _portfolioService.GetPortfolioList();
            return View(values);
        }

        public ActionResult Create()
        {

            ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Portfolio portfolio, IFormFile? Image1, IFormFile? Image2, IFormFile? Image3)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");

                    // Fotoğraf işlemleri...
                    if (Image1 is not null)
                    {
                        string klasor1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", Image1.FileName);
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        Image1.CopyTo(stream1);
                        portfolio.Image1 = Image1.FileName;
                    }
                    if (Image2 is not null)
                    {
                        string klasor2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", Image2.FileName);
                        using var stream2 = new FileStream(klasor2, FileMode.Create);
                        Image2.CopyTo(stream2);
                        portfolio.Image2 = Image2.FileName;
                    }
                    if (Image3 is not null)
                    {
                        string klasor3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img", Image3.FileName);
                        using var stream3 = new FileStream(klasor3, FileMode.Create);
                        Image3.CopyTo(stream3);
                        portfolio.Image3 = Image3.FileName;
                    }

                    _portfolioService.Add(portfolio);
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
                return View(portfolio);
            }
            catch
            {
                ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
                return View();
            }
        }

        // GET: HeaderController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
            var resultDataId = _portfolioService.GetByID(id);
            return View(resultDataId);
        }
        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Portfolio portfolio, IFormFile? Image1, IFormFile? Image2, IFormFile? Image3)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
                    if (Image1 is not null)
                    {
                        string klasor1 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image1.FileName;
                        using var stream1 = new FileStream(klasor1, FileMode.Create);
                        Image1.CopyTo(stream1);
                        portfolio.Image1 = Image1.FileName;
                    }
                    if (Image2 is not null)
                    {
                        string klasor2 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image2.FileName;
                        using var stream2 = new FileStream(klasor2, FileMode.Create);
                        Image2.CopyTo(stream2);
                        portfolio.Image2 = Image2.FileName;
                    }
                    if (Image3 is not null)
                    {
                        string klasor3 = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image3.FileName;
                        using var stream3 = new FileStream(klasor3, FileMode.Create);
                        Image3.CopyTo(stream3);
                        portfolio.Image3 = Image3.FileName;
                    }
                  

                    _portfolioService.Update(portfolio);
                }
                ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.PortfolioCategoryId = new SelectList(_portfolioCategoryService.GetList(), "Id", "Name");
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var heroToDelete = _portfolioService.GetByID(id);
                _portfolioService.Delete(heroToDelete);
                return RedirectToAction("Index"); // Silme işlemi başarılıysa Index sayfasına yönlendir
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return StatusCode(500); // İsteği işlerken bir hata oluşursa 500 Internal Server Error dön
            }
        }
    }
}
