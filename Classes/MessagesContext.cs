using ChatStudents.Classes.Common;
using ChatStudents.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents.Classes
{
    public class MessagesContext : DbContext
    {
        public DbSet<Messages> Messages { get; set; }

        public MessagesContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.config);
            }
        }
    }
}