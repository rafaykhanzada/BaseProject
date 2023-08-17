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
        public DbSet<CPClass> CPClass { get; set; }
        public DbSet<CPDeviation> CPDeviation { get; set; }
        public DbSet<Auditor> Auditor { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<FaultGroup> FaultGroup { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<Variant> Variant { get; set; }
        public DbSet<AuditType> AuditType { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Plant> Plant { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<Checkpoints> Checkpoints { get; set; }
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
            builder.Entity<CPClass>().ToTable($"tbl{nameof(CPClass)}");
            builder.Entity<CPDeviation>().ToTable($"tbl{nameof(CPDeviation)}");
            builder.Entity<Auditor>().ToTable($"tbl{nameof(Auditor)}");
            builder.Entity<Email>().ToTable($"tbl{nameof(Email)}");
            builder.Entity<FaultGroup>().ToTable($"tbl{nameof(FaultGroup)}");
            builder.Entity<Shift>().ToTable($"tbl{nameof(Shift)}");
            builder.Entity<Model>().ToTable($"tbl{nameof(Model)}");
            builder.Entity<Variant>().ToTable($"tbl{nameof(Variant)}");
            builder.Entity<AuditType>().ToTable($"tbl{nameof(AuditType)}");
            builder.Entity<Product>().ToTable($"tbl{nameof(Product)}");
            builder.Entity<Plant>().ToTable($"tbl{nameof(Plant)}");
            builder.Entity<Zone>().ToTable($"tbl{nameof(Zone)}");
            builder.Entity<Checkpoints>().ToTable($"tbl{nameof(Checkpoints)}");
            builder.Entity<Category>().ToTable($"tbl{nameof(Category)}");
            builder.Entity<Role>().ToTable($"tbl{nameof(Role)}");
            builder.Entity<ActivityLog>().ToTable($"tbl{nameof(ActivityLog)}");
            builder.Entity<ScheduleJob>().ToTable($"tbl{nameof(ScheduleJob)}");
            builder.Entity<User>().ToTable($"tbl{nameof(User)}");
            builder.Entity<Menu>().ToTable($"tbl{nameof(Menu)}");
            builder.Entity<RefreshToken>().ToTable($"tbl{nameof(RefreshToken)}");
            builder.Entity<Permission>().ToTable($"tbl{nameof(Permission)}");
            builder.Entity<User>().Property(x => x.UserId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            builder.Entity<Role>().Property(x => x.RoleId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        }
    }
}
