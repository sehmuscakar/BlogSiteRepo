using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.ViewComponents
{
    public class ResumeViewComponent : ViewComponent
    {
        private readonly IResumeService _resumeService;

        public ResumeViewComponent(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listele = _resumeService.GetList();
            return View(listele);
        }
    }
}
