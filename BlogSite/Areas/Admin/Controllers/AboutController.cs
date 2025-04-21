using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {
            var values = _aboutService.GetList();
            return View(values);
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeaderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(About about, IFormFile? Image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (Image is not null)
                    {
                        string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream = new FileStream(klasor, FileMode.Create);
                        Image.CopyTo(stream);
                        about.Image = Image.FileName;
                    }
                    _aboutService.Add(about);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }

        // GET: HeaderController/Edit/5
        public ActionResult Edit(int id)
        {
            // ViewBag.dgr = _headerService.UserListManager();
            var resultDataId = _aboutService.GetByID(id);
            return View(resultDataId);
        }

        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, About about, IFormFile? Image)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    if (Image is not null)
                    {
                        string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream = new FileStream(klasor, FileMode.Create);
                        Image.CopyTo(stream);
                        about.Image = Image.FileName;
                    }
                    _aboutService.Update(about);
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
                var heroToDelete = _aboutService.GetByID(id);
                _aboutService.Delete(heroToDelete);
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
