using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ResumeController : Controller
    {
        private readonly IResumeService _resumeService;
        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }
        public IActionResult Index()
        {
            var values = _resumeService.GetList();
            return View(values);
        }
        public ActionResult Create()
        {

            return View();
        }
        // POST: HeaderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Resume resume)
        {
            try
            {
                _resumeService.Add(resume);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception hata)
            {
                Console.WriteLine("Mesaj : " + hata.Message);
                return View();
            }
        }
        public ActionResult Edit(int id)
        {

            var resultDataId = _resumeService.GetByID(id);
            return View(resultDataId);
        }
        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Resume resume)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    _resumeService.Update(resume);
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
                var heroToDelete = _resumeService.GetByID(id);
                _resumeService.Delete(heroToDelete);
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
