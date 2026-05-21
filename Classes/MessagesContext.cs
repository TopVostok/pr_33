using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatStudents.Classes.Common;
using ChatStudents.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChatStudents.Classes
{
    public class MessagesContext
    {
        public DbSet<Messages> Massages { get; set; }
        public MessagesContext() =>
            Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        // Говорим что используем SQL Server со следующей конфигурацией
        optionsBuilder.UseSqlServer(Config.config);
    }
}
