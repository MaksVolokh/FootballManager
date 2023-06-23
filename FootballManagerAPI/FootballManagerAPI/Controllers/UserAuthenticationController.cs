using FootballManagerBLL.Dto.UserDto;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        public UserAuthenticationController(IUserAuthenticationService  authServise)
        {
            _authService = authServise;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                
            var result = await _authService.LoginAsync(model);

            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }

            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Role = "user";
            var result = await _authService.RegisterAsync(model);

            if (result.StatusCode == 1)
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

            else
            {
                TempData["msg"] = result.Message;
                return View(model);
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();

            return RedirectToAction(nameof(Login));
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }


        [Authorize]
        [HttpPost("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
            { 
                return View(model);
            }

            var result = await _authService.ChangePasswordAsync(model, User.Identity.Name);
            TempData["msg"] = result.Message;

            return RedirectToAction(nameof(ChangePassword));
        }

    }
}

