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

        public async Task SeedRolesAsync()
        {
            if (!await _roleManager.RoleExistsAsync("User"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = "User"
                });

                if (!roleResult.Succeeded)
                {
                    var errors = string.Join("; ", roleResult.Errors.Select(e => e.Description));
                    throw new InvalidOperationException($"Failed to seed role 'User': {errors}");
                }
            }
        }

        public async Task SeedUsersAsync()
        {
            var existingUser = await _userManager.FindByEmailAsync("user@localhost");
            if (existingUser != null)
            {
                return;
            }

            var user = new ApplicationUser
            {
                UserName = "user@localhost",
                Email = "user@localhost",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(user, "Numsey#2024");
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to seed user 'user@localhost': {errors}");
            }

            var addToRoleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!addToRoleResult.Succeeded)
            {
                var errors = string.Join("; ", addToRoleResult.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Failed to assign role 'User' to 'user@localhost': {errors}");
            }
        }
    }
}
