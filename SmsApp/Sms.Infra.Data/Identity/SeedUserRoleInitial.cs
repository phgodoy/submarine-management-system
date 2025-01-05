using Microsoft.AspNetCore.Identity;
using Sms.Domain.Accont;

namespace Sms.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(RoleManager<IdentityRole> roleManager,
                UserManager<ApplicationUser> userManager) 
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public void SeedRoles()
        {
          if( _userManager.FindByEmailAsync("user@Localhost").Result == null )
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "user@Localhost";
                user.Email = "user@Localhost";
                user.NormalizedUserName = "USER@LOCALHOST";
                user.NormalizedEmail = "USER@LOCALHOST";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user, "Numsey#2024").Result;

                if (result.Succeeded) 
                {
                    _userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }

        public void SeedUsers()
        {
            if (!_roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                role.NormalizedName = "USER";
                IdentityResult roleResult = _roleManager.CreateAsync(role).Result;
            }
        }
    }
}
