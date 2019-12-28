using BaseWebApp.Models.Helpers;
using BaseWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseWebApp.ViewModels
{
    public abstract class BaseViewModel
    {
        public AppSettings AppSettings { get; set; }
        public AppUser CurrentUser { get; set; }
        public bool IsDev { get; set; }
        public bool IsSupport { get; set; }
        public bool IsUser { get; set; }
    }
}

