using FootballManagerBLL.Dto.UserDto;
using FootballManagerBLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManagerAPI.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationService _authService;
        private readonly IStringLocalizer<UserAuthenticationController> _localizer;
        public UserAuthenticationController(IUserAuthenticationService  authServise, IStringLocalizer<UserAuthenticationController> localizer)
        {
            _authService = authServise;
            _localizer = localizer;
        }
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost("Login")]
        [Produces("application/json")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new { errors });
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
        [Produces("application/json")]
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
        [Produces("application/json")]
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

