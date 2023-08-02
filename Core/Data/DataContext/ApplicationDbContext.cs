using Core.Data.Entities;
using Core.Utilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Core.Data.DataContext
{
    public class ApplicationDbContext: IdentityDbContext<User, Role, string>
    {
        public ApplicationDbContext()
        { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Category> Category { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<ScheduleJob> ScheduleJob { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Permission> Permission { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConfigHelper.config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable($"tbl{nameof(Category)}");
            builder.Entity<Role>().ToTable($"tbl{nameof(Role)}");
            builder.Entity<ActivityLog>().ToTable($"tbl{nameof(ActivityLog)}");
            builder.Entity<ScheduleJob>().ToTable($"tbl{nameof(ScheduleJob)}");
            builder.Entity<User>().ToTable($"tbl{nameof(User)}");
            builder.Entity<Menu>().ToTable($"tbl{nameof(Menu)}");
            builder.Entity<RefreshToken>().ToTable($"tbl{nameof(RefreshToken)}");
            builder.Entity<Permission>().ToTable($"tbl{nameof(Permission)}");
        }
    }
}
