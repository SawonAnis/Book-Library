using Book_Library_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_Library_API.Data
{
    public class LibraryContext:DbContext
    {
        public LibraryContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

     public DbSet<Book> Books { get; set; }
    }
}
