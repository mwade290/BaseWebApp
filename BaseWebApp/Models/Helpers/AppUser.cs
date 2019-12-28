using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseWebApp.Models.Helpers
{
    public enum UserRole
    {
        Developer,
        Support,
        User
    }

    public class AppUser
    {
        private string _displayName = null;
        public string UserName { get; set; }

        public string DisplayName
        {
            get
            {
                if (_displayName is null)
                {
                    return "<User Unknown>";
                }
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }
        // Uses HashSet instead of list to ensure unique
        public HashSet<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
        public virtual bool HasRole(UserRole role)
        {
            return UserRoles.Any(a => a == role);
        }

    }
}

