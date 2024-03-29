using FootballManagerBLL.Dto;

namespace FootballManagerDAL.Entities
{
    public class ChatUser
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public UserRole Role { get; set; }
    }
}