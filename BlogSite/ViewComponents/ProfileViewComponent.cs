using BlogSite.Areas.Admin.Models;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            AppUserEditModel appUserEditDto = new AppUserEditModel();
            appUserEditDto.Name = values.Name;
            appUserEditDto.LastName = values.LastName;
            appUserEditDto.About = values.About;
            appUserEditDto.Image = appUserEditDto.Image;
            appUserEditDto.Image = values.Image;
            return View(appUserEditDto);
        }

    }
}
