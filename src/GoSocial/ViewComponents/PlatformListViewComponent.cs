using GoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.ViewComponents
{
    public class PlatformListViewComponent : ViewComponent
    {
        private GoSocialContext db;
        public PlatformListViewComponent(GoSocialContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {                var platforms = (from x in db.Platform
                                  select x).ToList();

                return View(platforms);
         }
    }
}
