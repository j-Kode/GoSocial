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
using System.Security.Claims;

namespace GoSocial.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private GoSocialContext db;

        public HomeController(
            UserManager<ApplicationUser> userManager, GoSocialContext db)
        {
            _userManager = userManager;
            this.db = db;
        }

        [Authorize]
        public IActionResult Index(int IndustryId, int cityId)
        {
            if (IndustryId != 0 && cityId != 0)
            {
                return View(db.Posting.Include(c => c.City).Include(u => u.User).Where(p=> p.IndustryId == IndustryId && p.CityId == cityId).ToList());
            }
            else
            {
                return View(db.Posting.Include(c => c.City).Include(u => u.User).ToList());
            }

            

        }
        [HttpGet]
        public ActionResult Search(string term)
        {
            var result = (from c in db.City join s in db.State
                          on c.StateId equals s.Id where c.City1.StartsWith(term)
                          select new { label = c.City1 + ", " + s.StateCode, value=c.Id }).Take(10).ToList();
            return Json(result);
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
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {

                var user = db.Users.Where(u => u.UserName == message.ToUserId.Substring(1)).FirstOrDefault();
                message.CreateDate = DateTime.UtcNow;
                message.FromUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                message.ToUserId = user.Id;
                message.StatusId = 1;
                db.Message.Add(message);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCampaign(Posting posting)
        {
            if (ModelState.IsValid)
            {
                    posting.Date = DateTime.UtcNow;
                    posting.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value; //Added 1 for userid, testing purpose.
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
