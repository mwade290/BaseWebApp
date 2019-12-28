using BaseWebApp.Models.Helpers;
using System.Collections.Generic;

namespace BaseWebApp.Controllers
{
    public class UserController
    {
        private readonly AppSettings _appSettings;

        public UserController(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        /// <summary>
        /// Takes a username, then returns an AppUser object of that user.
        /// This is intended to be used for navigating through the BaseWebApp application.
        /// </summary>
        public AppUser GetUserFromUsername(string username)
        {
            // TODO: Configure this class depending on the infrastructure setup
            return new AppUser
            {
                UserName = username,
                DisplayName = "Anonymous",
                UserRoles = new HashSet<UserRole> { UserRole.Developer }
            };
        }
    }
}
