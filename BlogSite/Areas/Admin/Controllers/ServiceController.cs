using Business.Abstract;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        // GET: ServiceController
        public ActionResult Index()
        {
            return View(_serviceService.GetList());
        }

        // GET: ServiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Service service)
        {
            try
            {
                _serviceService.Add(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ServiceController/Edit/5
        public ActionResult Edit(int id)
        {
            var resultDataId = _serviceService.GetByID(id);
            return View(resultDataId);
          
        }

        // POST: ServiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Service service)
        {
            try
            {
                _serviceService.Update(service);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                var heroToDelete = _serviceService.GetByID(id);
                _serviceService.Delete(heroToDelete);
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
