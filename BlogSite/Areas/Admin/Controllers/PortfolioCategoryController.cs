using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class PortfolioCategoryController : Controller
    {
        private readonly IPortfolioCategoryService _portfolioCategoryService;

        public PortfolioCategoryController(IPortfolioCategoryService portfolioCategoryService)
        {
            _portfolioCategoryService = portfolioCategoryService;
        }

        public IActionResult Index()
        {
            var values = _portfolioCategoryService.GetList();
            return View(values);
        }



        // GET: PortfolioCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PortfolioCategory portfolioCategory)
        {
            try
            {
                _portfolioCategoryService.Add(portfolioCategory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {

            var resultDataId = _portfolioCategoryService.GetByID(id);
            return View(resultDataId);
        }
        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PortfolioCategory portfolioCategory)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _portfolioCategoryService.Update(portfolioCategory);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }



        public ActionResult Delete(int id)
        {
            try
            {
                var heroToDelete = _portfolioCategoryService.GetByID(id);
                _portfolioCategoryService.Delete(heroToDelete);
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
