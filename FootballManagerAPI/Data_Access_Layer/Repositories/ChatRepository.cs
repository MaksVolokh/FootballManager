using FootballManagerAPI.Data;
using FootballManagerDAL.Entities;
using FootballManagerDAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerDAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly DataContext _context;
        public ChatRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Chat> GetChatAsync(int id)
        {
            return await _context.Chats
                .Include(x => x.Messages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateRoomAsync(string name, string userId)
        {
            var chat = new Chat
            {
                Name = name,
                Type = ChatType.Room
            };

            chat.Users.Add(new ChatUser
            {
                UserId = userId,
                Role = UserRole.Admin
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();
        }

        public async Task JoinRoomAsync(int chatId, string userId)
        {
            var chatUser = new ChatUser
            {
                ChatId = chatId,
                UserId = userId,
                Role = UserRole.Member
            };

            _context.ChatUsers.Add(chatUser);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Chat>> GetChatsAsync(string userId)
        {
            return await _context.Chats
                .Include(x => x.Users)
                .Where(x => !x.Users.Any(y => y.UserId == userId))
                .ToListAsync();
        }

        public async Task<int> CreatePrivateRoomAsync(string rootId, string targetId)
        {
            var chat = new Chat
            {
                Type = ChatType.Private
            };

            chat.Users.Add(new ChatUser
            {
                UserId = targetId
            });

            chat.Users.Add(new ChatUser
            {
                UserId = rootId
            });

            _context.Chats.Add(chat);

            await _context.SaveChangesAsync();

            return chat.Id;
        }

        public async Task<List<Chat>> GetPrivateChatsAsync(string userId)
        {
            return await _context.Chats
                   .Include(x => x.Users)
                   .ThenInclude(x => x.User)
                   .Where(x => x.Type == ChatType.Private && x.Users
                   .Any(y => y.UserId == userId))
                   .ToListAsync();
        }

        public async Task<Message> CreateMessageAsync(int chatId, string message, string userId)
        {
            var Message = new Message
            {
                ChatId = chatId,
                Text = message,
                Name = userId,
                Timestamp = DateTime.Now
            };

            _context.Messages.Add(Message);
            await _context.SaveChangesAsync();

            return Message;
        }

    }
}
