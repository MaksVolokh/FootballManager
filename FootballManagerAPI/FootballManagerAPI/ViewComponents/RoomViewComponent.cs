using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace FootballManagerAPI.ViewComponents
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly DataContext _context;
        public RoomViewComponent(DataContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var chats = _context.ChatUsers
                .Include(x => x.Chat)
                .Where(x => x.UserId == userId && x.Chat.Type == ChatType.Room)
                .Select(x => x.Chat)
                .ToList();

            return View(chats);
        }
    }
}
