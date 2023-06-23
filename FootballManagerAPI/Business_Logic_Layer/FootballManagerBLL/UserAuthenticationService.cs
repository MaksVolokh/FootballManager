using FootballManagerBLL.Dto.UserDto;
using FootballManagerBLL.Dto;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using FootballManagerBLL.Interfaces;
using FootballManagerDAL.Interfaces;

namespace FootballManagerBLL.FootballManagerBLL
{
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserAuthenticationService(IUserRepository userRepository, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _roleManager = roleManager;
            _signInManager = signInManager;

        }

        public async Task<Status> RegisterAsync(RegistrationModel model)
        {
            var status = new Status();
            var userExists = await _userRepository.GetUserByUsernameAsync(model.Username);

            if (userExists != null)
            {
                status.StatusCode = 0;
                status.Message = "User already exist!";
                return status;
            } 

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var result = await _userRepository.CreateAsync(user, model.Password);

            if (!result)
            {
                status.StatusCode = 0;
                status.Message = "User creation failed!";
                return status;
            }

            if (!await _roleManager.RoleExistsAsync(model.Role))
            {
                await _roleManager.CreateAsync(new IdentityRole(model.Role));
            }

            if (await _roleManager.RoleExistsAsync(model.Role))
            {
                await _userRepository.AddUserToRoleAsync(user, model.Role);
            }

            status.StatusCode = 1;
            status.Message = "You have registered successfully!";

            return status;
        }


        public async Task<Status> LoginAsync(LoginModel model)
        {
            var status = new Status();
            var user = await _userRepository.GetUserByUsernameAsync(model.Username);

            if (user == null)
            {
                status.StatusCode = 0;
                status.Message = "Invalid username!";
                return status;
            }

            if (!await _userRepository.CheckPasswordAsync(user, model.Password))
            {
                status.StatusCode = 0;
                status.Message = "Invalid Password!";
                return status;
            }

            var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, false, true);

            if (signInResult.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                status.StatusCode = 1;
                status.Message = "Logged in successfully!";
            }

            else if (signInResult.IsLockedOut)
            {
                status.StatusCode = 0;
                status.Message = "User is locked out!";
            }

            else
            {
                status.StatusCode = 0;
                status.Message = "Error on logging in!";
            }

            return status;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();

        }

        public async Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username)
        {
            var status = new Status();
            var user = await _userRepository.GetUserByUsernameAsync(username);

            if (user == null)
            {
                status.Message = "User does not exist";
                status.StatusCode = 0;
                return status;
            }

            var result = await _userRepository.ChangePasswordAsync(user, model.NewPassword);

            if (result)
            {
                status.Message = "Password has updated successfully!";
                status.StatusCode = 1;
            }

            else
            {
                status.Message = "Some error occured";
                status.StatusCode = 0;
            }

            return status;
        }
    }
}
