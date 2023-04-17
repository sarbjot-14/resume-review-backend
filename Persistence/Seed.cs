
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
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