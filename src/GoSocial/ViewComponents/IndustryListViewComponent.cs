using GoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.ViewComponents
{
    public class IndustryListViewComponent : ViewComponent
    {
        private GoSocialContext db;
        public IndustryListViewComponent(GoSocialContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
                var industries = (from x in db.Industry
                                  select x).ToList();

                return View(industries);
         
           
        }
    }
}
