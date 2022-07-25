using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Tasker.DataModels
{
    public class TaskerContext : DbContext
    {

        public TaskerContext()
            : base()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Tasker;Trusted_Connection=True;");
        }

        public DbSet<Task> Tasks { get; set; }
    }
}
