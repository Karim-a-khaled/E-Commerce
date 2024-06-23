using Microsoft.AspNetCore.Identity;
using PartTwo.Entities.Entities.Identity;

namespace PartTwo.Data.SeedData;

public static class AppIdentitySeed
{
    public static void SeedUsers(this UserManager<AppUser> userManager)
    {
        if (!userManager.Users.Any())
        {
            var user = new AppUser
            {
                DisplayName = "bob",
                Email = "string@example.com",
                UserName = "bob@example.com",
                Address = new Address
                {
                    FirstName = "bob",
                    LastName = "bob",
                    City = "New York",
                    State = "NY",
                    Street = "10 the street",
                    ZipCode = "902210"
                }
            };

            userManager.CreateAsync(user, "string");
        }
    }
}