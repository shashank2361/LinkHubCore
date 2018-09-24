using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHUI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [AllowAnonymous]
    public class BrowseURLsController : Controller
    {
        ILHUrlBs LHUrlBs;
        public BrowseURLsController(ILHUrlBs _LHUrlBs)
        {
            LHUrlBs = _LHUrlBs;
        }
        public IActionResult Index()
        {
            List<BrowseURLSViewModel> browseURLs = new List<BrowseURLSViewModel>();
            var urls = LHUrlBs.GetAll(true);
            browseURLs = urls.Select(x => new BrowseURLSViewModel{
                    UrlId = x.UrlId,
                    UrlTitle = x.UrlTitle,
                    LHUrlName = x.LHUrlName,
                    Description = x.Description,
                    CategoryName = x.Category.CategoryName,
                    UserName = x.User.UserName
                  }).ToList();




            return View(browseURLs);
        }
    }
}