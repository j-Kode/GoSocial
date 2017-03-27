using GoSocial.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoSocial.Helpers
{
    public static class IdentityExtensions
    {
        public static async Task<ApplicationUser> FindByNameOrEmailAsync
           (this UserManager<ApplicationUser> userManager, string usernameOrEmail)
        {
            var username = usernameOrEmail;
            if (usernameOrEmail.Contains("@"))
            {
                var userForEmail = await userManager.FindByEmailAsync(usernameOrEmail);
                if (userForEmail != null)
                {
                    username = userForEmail.UserName;
                }
            }
            return await userManager.FindByNameAsync(username);
        }
        public static async Task<ApplicationUser> UsernameInUse(this UserManager<ApplicationUser> userManager, string username)
        {
            return await userManager.FindByNameAsync(username);
        }
        public static IEnumerable<Message> GetUserMessages(this UserManager<ApplicationUser> userManager, ApplicationUser user, GoSocialContext db)
        {
            var userId = user.Id;
            IQueryable<Message> messages = null;
            if (userId != null)
            {

                messages = db.Message.Include(u => u.FromUser).Where(m => m.ToUserId == userId && m.StatusId == 1).OrderByDescending(x => x.CreateDate);

            }
            return messages;
        }
        public static IEnumerable<Message> GetUserSentMessages(this UserManager<ApplicationUser> userManager, ApplicationUser user, GoSocialContext db)
        {
            var userId = user.Id;
            IQueryable<Message> messages = null;
            if (userId != null)
            {

                messages = db.Message.Include(u => u.FromUser).Where(m => m.FromUserId == userId && (m.StatusId == 1 || m.StatusId == 2)).OrderByDescending(x => x.CreateDate);

            }
            return messages;
        }
        public static IEnumerable<Message> GetUserArchivedMessages(this UserManager<ApplicationUser> userManager, ApplicationUser user, GoSocialContext db)
        {
            var userId = user.Id;
            IQueryable<Message> messages = null;
            if (userId != null)
            {

                messages = db.Message.Include(u => u.FromUser).Where(m => m.ToUserId == userId && (m.StatusId == 3)).OrderByDescending(x => x.CreateDate);

            }
            return messages;
        }
    }
}
