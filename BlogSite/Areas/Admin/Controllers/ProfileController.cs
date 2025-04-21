using BlogSite.Areas.Admin.Models;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var listele = _userManager.Users.ToList();
            return View(listele);
        }

        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditModel appUserEditDto = new AppUserEditModel();
            appUserEditDto.Name = values.Name;
            appUserEditDto.LastName = values.LastName;
            appUserEditDto.Phone = values.Phone;
            appUserEditDto.Email = values.Email;
            appUserEditDto.About = values.About;
            appUserEditDto.Image = appUserEditDto.Image;
            appUserEditDto.Adress = values.Adress;
            appUserEditDto.Image = values.Image;
            return View(appUserEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> MyAccount(AppUserEditModel appUserEditDto, IFormFile? Image)
        {
            if (appUserEditDto.Password == appUserEditDto.ConfirmPassword)
            {
                if (!ModelState.IsValid)
                {
                    if (Image is not null)
                    {
                        string klasor = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                        using var stream = new FileStream(klasor, FileMode.Create);
                        Image.CopyTo(stream);
                        appUserEditDto.Image = Image.FileName;
                    }
                }
                var user = await _userManager.FindByNameAsync(User.Identity.Name);

                user.Phone = appUserEditDto.Phone;
                user.LastName = appUserEditDto.LastName;
                user.About = appUserEditDto.About;
                user.Adress = appUserEditDto.Adress;
                user.Name = appUserEditDto.Name;
                user.Image = appUserEditDto.Image;
                user.Email = appUserEditDto.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, appUserEditDto.Password);
                var resut = await _userManager.UpdateAsync(user);
                if (resut.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }

            }
            return View();
        }

    }
}
