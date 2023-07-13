using FootballManagerDAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace FootballManagerBLL.Dto
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base()
        {
            Chats = new List<ChatUser>();
        }
        public ICollection<ChatUser> Chats { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
