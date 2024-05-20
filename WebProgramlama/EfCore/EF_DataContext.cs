using Microsoft.EntityFrameworkCore;

namespace WebProgramlama.EfCore
{
    public class EF_DataContext: DbContext  
    {
        public EF_DataContext(DbContextOptions<EF_DataContext> options): base(options) { }
        
        public DbSet<Customer> Customer { get; set; }

    }
}
