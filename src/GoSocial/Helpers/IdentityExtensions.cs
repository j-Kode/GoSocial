using GoSocial.Models;
using Microsoft.AspNetCore.Identity;
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
        public static List<Message> GetUserMessages (this UserManager<ApplicationUser> userManager, ApplicationUser user, GoSocialContext db)
        {
            var userId = user.Id;
            var messages = new List<Message>();
            if(userId != null)
            {

                    messages = (from m in db.Message
                                    where m.ToUserId == userId
                                    select m).ToList();
                    
            }
            return messages;
        }
    }
}
