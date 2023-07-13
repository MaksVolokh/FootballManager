using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using FootballManagerBLL.Interfaces;
using FootballManagerAPI.Hubs;
using FootballManagerAPI.Data;
using System.Linq;

namespace FootballManagerAPI.Controllers
{
        [Authorize]
        public class ChatController : BaseController
        {
            private IChatService _service;
            public ChatController(IChatService service)
            {
                _service = service;
            }
            
            [Produces("application/json")]
            public IActionResult Index()
            {
                var chats = _service.GetChatsAsync(GetUserId());

                return View(chats);
            }

            public IActionResult Find([FromServices] DataContext context)
            {
                var users = context.Users
                    .Where(x => x.Id != User.GetUserId())
                    .ToList();

                return View(users);
            }

            public async Task<IActionResult> Private()
            {
                var chats = await _service.GetPrivateChatsAsync(GetUserId());

                return View(chats);
            }

            [HttpPost("PrivateRoom")]
            [Produces("application/json")]
            public async Task<IActionResult> CreatePrivateRoomAsync(string userId)
            {
                var chatId = await _service.CreatePrivateRoomAsync(GetUserId(), userId);

                return RedirectToAction("Chat", new { chatId });
            }

            [HttpGet("Chat {id}")]
            [Produces("application/json")]
            public async Task<IActionResult> ChatAsync(int id)
            {
                return View(await _service.GetChatAsync(id));
            }

            [HttpPost("CreateRoom")]
            [Produces("application/json")]
            public async Task<IActionResult> CreateRoomAsync(string name)
            {
                await _service.CreateRoomAsync(name, GetUserId());
                return RedirectToAction("Index");
            }

            [HttpGet("JoinRoom")]
            [Produces("application/json")]
            public async Task<IActionResult> JoinRoomAsync(int id)
            {
                await _service.JoinRoomAsync(id, GetUserId());

                return RedirectToAction("Chat", "Chat", new { id = id });
            }

            public async Task<IActionResult> SendMessageAsync(int roomId, string message,[FromServices] IHubContext<ChatHub> chat)
            {
                var Message = await _service.CreateMessageAsync(roomId, message, User.Identity.Name);

                await chat.Clients.Group(roomId.ToString())
                    .SendAsync("RecieveMessage", new
                    {
                        Text = Message.Text,
                        Name = Message.Name,
                        Timestamp = Message.Timestamp.ToString("dd/MM/yyyy hh:mm:ss")
                    });

                return Ok();
            }
        }
    }
