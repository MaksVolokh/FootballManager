using FootballManagerBLL.Dto;

namespace FootballManagerDAL.Interfaces
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByUsernameAsync(string username);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<bool> CreateAsync(ApplicationUser user, string password);
        Task<bool> AddUserToRoleAsync(ApplicationUser user, string role);
        Task<bool> ChangePasswordAsync(ApplicationUser user, string newPassword);
    }
}
