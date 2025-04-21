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
        public async Task<IActionResult> SignIn(LoginModel loginModel) // peek defination diyereek direk bu sayfanın içinden  o modelini dolduurabilirsin
        {
            if (!Regex.IsMatch(loginModel.Username, "^[a-zA-Z0-9_-]+$"))
            {
                ModelState.AddModelError("UserName", "Geçersiz karakterler kullanıldı. Sadece harf, rakam, alt tire (_) ve tire (-) kullanabilirsiniz.");
                ViewBag.ErrorMessage = "Kullanıcı Adı alanında geçersiz karakterler kullanıldı. Sadece harf, rakam, alt tire (_) ve tire (-) kullanabilirsiniz.";
                return View();
            }
            var result = await _signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, true, true);//true,true ;1.ci true browser kapandıktan sonra sişfre hatırlansın mı
                                                                                                                                //2.ci true ise accessfailedcount nin aktif olması yani kullanıcı her yanlış girdiğinde 1 artacak ve 5 olduğunda onu loglayacak engeleyece beli süre aralığında 20 dk ciivarı herhalde bilmiyorum tam 
            if (result.Succeeded)
            {
                _userManager.FindByNameAsync(loginModel.Username);//kayıt olan username i bulur ,bu olmazsa appuser gti hep boş gelir ,bulamazmıyor çünkü,//kayıt olan username i bulur,burda 4 şeye göre bulur kayıt olan user 1.FindByIdAsync userıd ye göre

                return RedirectToAction("Index", "Profile");
            }


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
