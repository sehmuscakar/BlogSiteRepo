using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            var values = _skillService.GetList();
            return View(values);
        }
        public ActionResult Create()
        {

            return View();
        }

        // POST: HeaderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Skill skill)
        {
            try
            {
                _skillService.Add(skill);

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

            var resultDataId = _skillService.GetByID(id);
            return View(resultDataId);
        }

        // POST: HeaderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Skill skill)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    _skillService.Update(skill);
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
                var heroToDelete = _skillService.GetByID(id);
                _skillService.Delete(heroToDelete);
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
