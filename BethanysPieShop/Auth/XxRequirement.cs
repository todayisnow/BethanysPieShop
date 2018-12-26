using Microsoft.AspNetCore.Authorization;

namespace BethanysPieShop.Auth
{
    //https://stackoverflow.com/questions/42423282/dependency-injection-on-authorizationoptions-requirement-in-dotnet-core


    public class XxRequirement : IAuthorizationRequirement
    {
        public int MinimumOrderAge;

        public XxRequirement(int minimumOrderAge)
        {
            MinimumOrderAge = minimumOrderAge;
        }
    }
}