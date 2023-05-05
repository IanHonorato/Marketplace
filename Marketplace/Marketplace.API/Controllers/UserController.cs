using Marketplace.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Marketplace.API.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
