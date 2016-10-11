using GoSocial.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.ViewComponents
{
    public class CountryListViewComponent : ViewComponent
    {
        private GoSocialContext db;
        public CountryListViewComponent(GoSocialContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {
            var countries = (from x in db.Country
                             select x).ToList();

            return View(countries);
        }
    }
}
