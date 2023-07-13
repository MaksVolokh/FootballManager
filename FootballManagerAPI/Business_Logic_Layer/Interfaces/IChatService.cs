using FootballManagerDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerBLL.Interfaces
{
    public interface IChatService
    {
        Task<Chat> GetChatAsync(int id);
        Task CreateRoomAsync(string name, string userId);
        Task JoinRoomAsync(int chatId, string userId);
        Task<List<Chat>> GetChatsAsync(string userId);
        Task<int> CreatePrivateRoomAsync(string rootId, string targetId);
        Task<List<Chat>> GetPrivateChatsAsync(string userId);
        Task<Message> CreateMessageAsync(int chatId, string message, string userId);
    }
}
