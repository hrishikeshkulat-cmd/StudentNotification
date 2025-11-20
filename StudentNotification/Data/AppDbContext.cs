using Microsoft.EntityFrameworkCore;
using StudentNotification.Models;



namespace StudentNotification.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


       public DbSet<Student> Students {  get; set; }
     public DbSet<Notification>Notifications { get; set; }
    }
}
