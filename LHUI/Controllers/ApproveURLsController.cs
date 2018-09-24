﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LHBLL;
using LHUI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LHUI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class ApproveURLsController : Controller
    {
        ILHUrlBs LHUrlBs;
        public ApproveURLsController(ILHUrlBs _LHUrlBs)
        {
            LHUrlBs = _LHUrlBs;
        }
        public IActionResult Index()
        {
            List<ApproveURLsViewModel> approveURLs = new List<ApproveURLsViewModel>();
            var urls = LHUrlBs.GetAll(false);

            foreach (var item in urls)
            {
                ApproveURLsViewModel model = new ApproveURLsViewModel()
                {
                    UrlId = item.UrlId,
                    UrlTitle = item.UrlTitle,
                    LHUrlName = item.LHUrlName,
                    Description = item.Description,
                    CategoryName = item.Category.CategoryName,
                    UserName = item.User.UserName,
                    IsApproved=item.IsApproved                   
                };
                approveURLs.Add(model);
            }

            return View(approveURLs);
        }

        [HttpPost]
        public IActionResult Approve(int urlId)
        {
            var lhUrl = LHUrlBs.GetById(urlId);
            lhUrl.IsApproved = true;
            LHUrlBs.Update(lhUrl);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ApproveAll(List<int> urlIds)
        {
            if (urlIds.Count != 0)
            {
                foreach (var urlId in urlIds)
                {
                    var lhUrl = LHUrlBs.GetById(urlId);
                    lhUrl.IsApproved = true;
                    LHUrlBs.Update(lhUrl);
                }
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}