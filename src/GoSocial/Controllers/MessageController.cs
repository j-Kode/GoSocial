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
using System.Security.Claims;

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

        public ActionResult Archive(Message message)
        {
            message.StatusId = 3; //Setting message state to deleted, maybe this shouldnt be hardcoded
            db.Entry(message).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(Message message)
        {
            message.StatusId = 4; //Permanetly deleting message but still keeping it
            db.Entry(message).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        // POST: Message/Delete/5
        public ActionResult Restore(Message message)
        {
            message.StatusId = 2; //Permanetly deleting message but still keeping it
            db.Entry(message).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
        public IActionResult ReplyMessage(Message message)
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
    }
}