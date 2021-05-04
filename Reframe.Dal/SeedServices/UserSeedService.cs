using Microsoft.AspNetCore.Identity;
using Reframe.Dal.Entities;
using Reframe.Dal.SeedInterfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Reframe.Dal.SeedServices
{
    public class UserSeedService : IUserSeedService
    {
        private readonly UserManager<User> userManager;

        public UserSeedService(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task SeedUserAsync()
        {
            if (!( await userManager.GetUsersInRoleAsync(Roles.Roles.Administrator) ).Any())
            {
                var user = new User
                {
                    Email = "admin@bookshop.hu",
                    Name = "Adminisztrátor Aladár",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };

                var createResult = await userManager.CreateAsync(user, "$Administrator123");
                var addToRoleResult = await userManager.AddToRoleAsync(user, Roles.Roles.Administrator);

                if (!createResult.Succeeded || !addToRoleResult.Succeeded)
                {
                    throw new ApplicationException("Administrator clould not be created:" +
                        string.Join(", ", createResult.Errors.Concat(addToRoleResult.Errors).Select(e => e.Description)));
                }
            }
        }
    }
}
