using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using static ActorsCastings.Common.ApplicationRoles;

namespace ActorsCastings.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static async Task SeedRoles(this IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            var roles = AllRoles;

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }

    }
}
