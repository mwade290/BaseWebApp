using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaseWebApp.Models.Helpers;
using BaseWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BaseWebApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(AppSettings appSettings) : base(appSettings)
        {
        }

        public IActionResult Index()
        {
            var viewModel = PopulateViewModel(new GenericViewModel());
            return View(viewModel);
        }
    }
}
