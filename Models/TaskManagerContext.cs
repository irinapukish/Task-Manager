using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManager.Models;
namespace TaskManager.Models
{
    public class TaskManagerContext : IdentityDbContext<ApplicationUser>
    {
        public TaskManagerContext( DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }
        public DbSet<TaskModel> Tasks { get; set; }
    }
}
