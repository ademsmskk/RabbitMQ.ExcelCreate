using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RabbitMQ.ExcelCreate.Models
{
    public class AppDBContext:IdentityDbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) 
        {

        }
        public DbSet<UserFile> UserFile { get; set; }
    }
}
