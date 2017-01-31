using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GoSocial.Models;
using GoSocial.Models.MessageViewModels;
using GoSocial.Helpers;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;

namespace GoSocial.Controllers
{
    public class MessageController : Controller
    {
        private GoSocialContext db;

        private readonly UserManager<ApplicationUser> _userManager;
        const int _pageSize = 10;

        public MessageController(UserManager<ApplicationUser> userManager, GoSocialContext db)
        {
            this.db = db;
            _userManager = userManager;
        }
        // GET: Message
        public async Task<IActionResult> Index(int? page)
        {
            int pageNumber = page ?? 1;
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var model = _userManager.GetUserMessages(user, db);

            return View(model.ToPagedList(pageNumber, _pageSize));
        }
        public async Task<ActionResult> Received(int? page)
        {
            int pageNumber = page ?? 1;
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var messages = _userManager.GetUserMessages(user, db);
            return PartialView("~/Views/Message/Received.cshtml", messages.ToPagedList(pageNumber, _pageSize));
        }
        public async Task<ActionResult> Archived(int? page)
        {
            int pageNumber = page ?? 1;
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var messages = _userManager.GetUserArchivedMessages(user, db);
            return PartialView("~/Views/Message/Archived.cshtml", messages.ToPagedList(pageNumber, _pageSize));
        }
        // GET: Message/Details/5
        public ActionResult Details(int messageId)
        {
            var message = db.Message.Include(x => x.FromUser).Where(m => m.MessageId == messageId).FirstOrDefault();


            return PartialView("~/Views/Message/Details.cshtml", message);
        }

        public async Task<ActionResult> Sent(int? page)
        {
            int pageNumber = page ?? 1;
            var user = await GetCurrentUserAsync();
            if (user == null)
            {
                return View("Error");
            }
            var sentMessages = _userManager.GetUserSentMessages(user, db);


            return PartialView("~/Views/Message/Sent.cshtml", sentMessages.ToPagedList(pageNumber, _pageSize));
        }

        // GET: Message/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Message/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Message/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Message/Delete/5
        public ActionResult Delete(Message message)
        {
            message.StatusId = 3; //Setting message state to deleted, maybe this shouldnt be hardcoded
            db.Entry(message).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }

        // POST: Message/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}