using FootballManagerAPI.Data;
using FootballManagerBLL.Dto;
using FootballManagerDAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FootballManagerDAL.Repositories
{
    public class UserRepository : IUserRepository   
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;

        }

        public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(n => n.UserName == username);
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            var passwordValid = await _context.Users.AnyAsync(u => u.Id == user.Id && u.PasswordHash == password);

            return passwordValid;
        }

        public async Task<bool> CreateAsync(ApplicationUser user, string password)
        {
            var result = await _context.Users.AddAsync(user);

            if (result.State == EntityState.Added)
            {
                result.Entity.PasswordHash = password;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> AddUserToRoleAsync(ApplicationUser user, string role)
        {
            var roleExists = await _context.Roles.AnyAsync(r => r.Name == role);

            if (!roleExists)
            {
                await _context.Roles.AddAsync(new IdentityRole(role));
                await _context.SaveChangesAsync();
            }

            var userRole = new IdentityUserRole<string>()
            {
                UserId = user.Id,
                RoleId = (await _context.Roles.FirstOrDefaultAsync(r => r.Name == role))?.Id
            };

            await _context.UserRoles.AddAsync(userRole);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ChangePasswordAsync(ApplicationUser user, string newPassword)
        {
            user.PasswordHash = newPassword;
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
    }
}
