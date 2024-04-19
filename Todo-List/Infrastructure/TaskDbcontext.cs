using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Todo_List.Core;

namespace Todo_List.Infrastructure
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}