using BlogSite.Areas.Admin.Models;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(AppUserRegisterModel appUserRegisterDto) //AppUserRegisterDto bu modeli kullanma amacımız sadece gerekli propertyleri kullanmak için 
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    Name = appUserRegisterDto.Name,
                    LastName = appUserRegisterDto.LastName,
                    Email = appUserRegisterDto.Email,
                    UserName = appUserRegisterDto.UserName,
                    Image = "",
                    Phone = "",
                    Adress = "",
                    About = "",
                };
                // Email adresinin benzersiz olmasını sağlamak için kontrolü yapın
                var existingUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == appUser.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Bu email adresi zaten kullanılmaktadır.");
                    ViewBag.ErrorMessage = "Bu email adresi zaten kullanılmaktadır.";
                    return View();
                }
                if (!Regex.IsMatch(appUserRegisterDto.UserName, "^[a-zA-Z0-9_-]+$"))
                {
                    ModelState.AddModelError("UserName", "Geçersiz karakterler kullanıldı. Sadece harf, rakam, alt tire (_) ve tire (-) kullanabilirsiniz.");
                    ViewBag.ErrorMessage = "Kullanıcı Adı alanında geçersiz karakterler kullanıldı. Sadece harf, rakam, alt tire (_) ve tire (-) kullanabilirsiniz.";
                    return View();
                }
                // Yani, yeni kullanıcı oluşturabilirsiniz.
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
            }
            return View();
        }

    }
}
