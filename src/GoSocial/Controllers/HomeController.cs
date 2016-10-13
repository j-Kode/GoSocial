using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GoSocial.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace GoSocial.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private GoSocialContext db;
        
        public HomeController(GoSocialContext db)
        {
            this.db = db;
        }
        [Authorize]
        public IActionResult Index()
        {
            //var user = await GetCurrentUserAsync();
            //if (user == null)
            //{
            //    return View("Error");
            //}
            return View(db.Posting.Include(c => c.City).ToList());

        }
        [HttpGet]
        public ActionResult Search(string term)
        {
            return Json(db.Platform.Where(p => p.Platform1.StartsWith(term, StringComparison.OrdinalIgnoreCase)).Select(p => p.Platform1).ToList());
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [Authorize]
        public IActionResult AddCampaign()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCampaign(Posting posting)
        {
            if (ModelState.IsValid)
            {
                    posting.Date = DateTime.UtcNow;
                    posting.UserId = 1; //Added 1 for userid, testing purpose.
                    db.Posting.Add(posting);
                    db.SaveChanges();

                    return RedirectToAction("Index");
            }
            return View(posting);
        }
        [HttpGet]
        public JsonResult GetStates(int countryId)
        {
                var states = (from s in db.State
                              where s.CountryId == countryId
                              select
                               new SelectListItem
                               {
                                   Value = s.Id.ToString(),
                                   Text = s.State1

                               }).ToList();

                return Json(states);
                 }

        [HttpGet]
        public JsonResult GetCities(int stateId)
        {
                var cities = (from c in db.City
                              where c.StateId == stateId
                              select
                              new SelectListItem
                              {
                                  Value = c.Id.ToString(),
                                  Text = c.City1
                              }).ToList();

                return Json(cities);
         
        }
        //private Task<ApplicationUser> GetCurrentUserAsync()
        //{
        //    return _userManager.GetUserAsync(HttpContext.User);
        //}
    }
}
