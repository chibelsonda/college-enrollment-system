using Microsoft.AspNetCore.Identity;

namespace CollegeEnrollmentSystem.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAsync(IServiceProvider services)
        {
            var roleManager =
                services.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roles = { "Admin", "Student" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
