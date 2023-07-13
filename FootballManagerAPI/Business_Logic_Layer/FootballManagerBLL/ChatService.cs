using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;


namespace FootballManagerBLL.FootballManagerBLL
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _repository;
        public ChatService(IChatRepository repository)
        {
            _repository = repository;
        }

        public Task<Chat> GetChatAsync(int id)
        {
            return _repository.GetChatAsync(id);
        }

        public Task CreateRoomAsync(string name, string userId)
        {
            return _repository.CreateRoomAsync(name, userId);
        }

        public Task JoinRoomAsync(int chatId, string userId)
        {
            return _repository.JoinRoomAsync(chatId, userId);
        }

        public Task<List<Chat>> GetChatsAsync(string userId)
        {
            return _repository.GetChatsAsync(userId);
        }

        public Task<int> CreatePrivateRoomAsync(string rootId, string targetId)
        {
            return _repository.CreatePrivateRoomAsync(rootId, targetId);
        }

        public Task<List<Chat>> GetPrivateChatsAsync(string userId)
        {
            return _repository.GetPrivateChatsAsync(userId);
        }

        public Task<Message> CreateMessageAsync(int chatId, string message, string userId)
        {
            return _repository.CreateMessageAsync(chatId, message, userId);
        }
    }
}
