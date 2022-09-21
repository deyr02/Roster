using API.models;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class Seed
    {
        public static async Task  SeedData(DataContext context, UserManager<User> userManager, RoleManager<UserRole> roleManager){
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

     
        if (!roleManager.Roles.Any()){

            var roles = new List<UserRole>{
                new UserRole {
                    Name = "Manager",
                    NormalizedName= "MANAGER"
                },
                 new UserRole {
                    Name = "Duty Manager",
                    NormalizedName= "DUTY MANAGER"
                },
                 new UserRole {
                    Name = "Front Staff",
                    NormalizedName= "FRONT STAFF"
                },
            };

            foreach (var role in roles){
             await  roleManager.CreateAsync(role);
            }
         
        }




        if (!context.Schedhules.Any()){

            var user = await userManager.FindByEmailAsync("bob@test.com");

            var schedhules = new List<Schedhule>{
                new Schedhule{
                    Date = DateTime.Now.AddDays(5),
                    Start = DateTime.Now.AddDays(5).AddHours(12).AddMinutes(30),
                    Finish = DateTime.Now.AddDays(5).AddHours(22).AddMinutes(30),
                    UserID = user.Id,
                },

                  new Schedhule{
                    Date = DateTime.Now.AddDays(6),
                    Start = DateTime.Now.AddDays(6).AddHours(12).AddMinutes(30),
                    Finish = DateTime.Now.AddDays(6).AddHours(22).AddMinutes(30),
                    UserID = user.Id,
                },
                  new Schedhule{
                    Date = DateTime.Now.AddDays(7),
                    Start = DateTime.Now.AddDays(7).AddHours(12).AddMinutes(30),
                    Finish = DateTime.Now.AddDays(7).AddHours(22).AddMinutes(30),
                    UserID = user.Id,
                },
            };

            foreach( var Schedhule in schedhules){
                context.Schedhules.Add(Schedhule);
            }
           await context.SaveChangesAsync();
        }
     }
    }
}