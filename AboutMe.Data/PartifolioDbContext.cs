using AboutMe.Domain;
using Microsoft.EntityFrameworkCore;

namespace AboutMe.Data
{
    public class PartifolioDbContext: DbContext
    {   
        public PartifolioDbContext(DbContextOptions<PartifolioDbContext>options)
            :base(options)
        {
            
        }
        public DbSet<Post> Posts {get; set;}        
    }
}
