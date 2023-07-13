using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FootballManagerAPI.Controllers
{
    public class BaseController : Controller
    {
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
