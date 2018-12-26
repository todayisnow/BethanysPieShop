using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BethanysPieShop.Auth
{
    public class XxRequirementHandler : AuthorizationHandler<XxRequirement>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public XxRequirementHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, 
                                                             XxRequirement requirement)
        {


            //var taskGetUser =  _userManager.GetUserAsync(context.User);
            //taskGetUser.Wait();
            //var birthDate = taskGetUser.Result.Birthdate;

            var user = await _userManager.GetUserAsync(context.User);
            var email = user.Email;

      

            if (!string.IsNullOrEmpty(email))
            {
                context.Succeed(requirement);
            }

            //return Task.CompletedTask;
        }
    }
}