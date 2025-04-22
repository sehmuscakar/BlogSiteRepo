using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Entities.Models;
using BlogSite.Areas.Admin.Models;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;// bu ikisi hazır sınıflar ıdentity kütüphanesinin 
        private readonly UserManager<AppUser> _userManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.Username) || !Regex.IsMatch(loginModel.Username, "^[a-zA-Z0-9_-]+$"))
            {
                ModelState.AddModelError("UserName", "Geçersiz karakterler kullanıldı.");
                ViewBag.ErrorMessage = "Geçersiz karakterler kullandınız.";
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, true, true);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Username);
                return RedirectToAction("Index", "Profile");
            }

            ViewBag.ErrorMessage = "Giriş başarısız. Lütfen kullanıcı adı veya şifreyi kontrol edin.";
            return View();
        }


        //public IActionResult Error404(int code)//program.cs te bu premtreeyi verdik
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> LogOut()//sistemden çıkış yapma
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("SignIn", "Login");
        }
    }
}
