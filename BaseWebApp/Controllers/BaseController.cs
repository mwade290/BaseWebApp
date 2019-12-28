using BaseWebApp.Models;
using BaseWebApp.Models.Helpers;
using BaseWebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BaseWebApp.Controllers
{
    [AutoValidateAntiforgeryToken]
    public abstract class BaseController : Controller
    {
        private readonly AppSettings _appSettings;
        private readonly UserController _userController;
        private AppUser _user = null;

        private AppUser CurrentUser
        {
            get
            {
                if (_user is null)
                {
                    _user = _userController.GetUserFromUsername(User.Identity.Name);
                }
                return _user;
            }
        }

        protected BaseController(AppSettings appSettings)
        {
            _appSettings = appSettings;
            _userController = new UserController(appSettings);
        }

        /// <summary>
        /// Takes in an anonymous ViewModel which inherits from BaseViewModel.
        /// Populates ViewModel with public properties.
        /// </summary>
        /// <typeparam name="T">A ViewModel type which inherits from BaseViewModel.</typeparam>
        /// <param name="viewModel">A ViewModel which requires populating.</param>
        /// <returns>Returns the same object but with some public fields populated.</returns>
        public T PopulateViewModel<T>(T viewModel) where T : BaseViewModel
        {
            viewModel.AppSettings = _appSettings;
            viewModel.CurrentUser = CurrentUser;
            viewModel.IsDev = CurrentUser.HasRole(UserRole.Developer);
            viewModel.IsSupport = CurrentUser.HasRole(UserRole.Support);
            viewModel.IsUser = CurrentUser.HasRole(UserRole.User);

            if (!viewModel.IsDev && !viewModel.IsSupport && !viewModel.IsUser)
            {
                throw new BaseWebAppException("User does not have the required permissions.");
            }

            return viewModel;
        }
    }
}
