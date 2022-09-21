using API.models;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class Seed
    {
        public static async Task  SeedData(DataContext context, UserManager<User> userManager){
             if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        FirstName= "Bob",
                        LastName = "Smith",
                        MobileNumber= "02102960832",
                        IRD = "111111111111",
                        Address= "26 Te Taou Crescent, Auckland Central, 1010, Auckland, New Zealand",
                        UserName = "bob",
                        Email = "bob@test.com",
                       // EmailConfirmed = true,
                        
                    },
                    new User
                    {   FirstName= "Jane",
                        LastName = "Smith",
                        MobileNumber= "02102960832",
                        IRD = "111111111111",
                        Address= "26 Te Taou Crescent, Auckland Central, 1010, Auckland, New Zealand",
                        UserName = "jane",
                        Email = "jane@test.com",
                         // EmailConfirmed = true,
                    },
                    new User
                    {
                        FirstName= "Tom",
                        LastName = "Smith",
                        MobileNumber= "02102960832",
                        IRD = "111111111111",
                        Address= "26 Te Taou Crescent, Auckland Central, 1010, Auckland, New Zealand",
                        UserName = "tom",
                        Email = "tom@test.com",
                         // EmailConfirmed = true,
                        
                    },
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
        }
     }
    }
}