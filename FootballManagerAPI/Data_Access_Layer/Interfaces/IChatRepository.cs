using FootballManagerDAL.Entities;

namespace FootballManagerDAL.Interfaces
{
    public interface IChatRepository
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
