
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context, UserManager<AppUser> userManager)
        {

            if(!userManager.Users.Any()){
                
             var users = new List<AppUser>
                {
                    new AppUser
                    {
                        DisplayName = "Bob",
                        UserName = "bob",
                        Email = "bob@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Jane",
                        UserName = "jane",
                        Email = "jane@test.com"
                    },
                    new AppUser
                    {
                        DisplayName = "Tom",
                        UserName = "tom",
                        Email = "tom@test.com"
                    },
                };
                foreach ( var user in users){
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
            }

            

            if (context.Resumes.Any()) return;
            
            var Resumes = new List<Resume>
            {
                new Resume
                {
                    
                    Date = DateTime.UtcNow.AddMonths(-2),
                    Author = "Brad",
                    Rating = 3,
              
                },
                new Resume
                {
                       Date = DateTime.UtcNow.AddMonths(-2),
                    Author = "John",
                    Rating = 4,
                },
                new Resume
                {
                   Date = DateTime.UtcNow.AddMonths(-2),
                    Author = "Sarah",
                    Rating = 1,
                },
            
             
            };

            await context.Resumes.AddRangeAsync(Resumes);
            await context.SaveChangesAsync();
        }
    }
}