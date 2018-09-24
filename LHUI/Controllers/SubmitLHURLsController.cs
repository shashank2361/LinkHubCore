using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHBOL;
using LHUI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    public class SubmitLHURLsController : Controller
    {
        UserManager<LHUser> userManager;
        ILHUrlBs LHUrlBs;
        ICategoryBs CategoryBs;
        public SubmitLHURLsController(UserManager<LHUser> _userManager, ILHUrlBs _LHUrlBs, ICategoryBs _CategoryBs)
        {
            LHUrlBs = _LHUrlBs;
            userManager = _userManager;
            CategoryBs = _CategoryBs;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateUrl()
        {
            ViewBag.Categories = CategoryBs.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUrl(CreateUrlViewModel model)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                LHUrl lHUrl = new LHUrl()
                {
                    UrlTitle = model.UrlTitle,
                    LHUrlName = model.LHUrlName,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    IsApproved = false,
                    Id = user.Id
                };
                LHUrlBs.Create(lHUrl);
                return RedirectToAction("CreateUrl");
            }
            ViewBag.Categories = CategoryBs.GetAll();
            return View();
        }
    }
}