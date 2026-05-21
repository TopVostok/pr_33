using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatStudents.Classes.Common;
using ChatStudents.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatStudents.Classes
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public UsersContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(Config.config);
    }
}