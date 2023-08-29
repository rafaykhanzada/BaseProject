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
    public class ApplicationDbContext: IdentityDbContext<Users, Role, string>
    {
        public ApplicationDbContext()
        { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<CheckpointClasses> CheckpointClasses { get; set; }
        public DbSet<CheckpointDeviations> CheckpointDeviations { get; set; }
        public DbSet<Auditors> Auditors { get; set; }
        public DbSet<Email> Email { get; set; }
        public DbSet<FaultGroups> FaultGroups { get; set; }
        public DbSet<Shifts> Shifts { get; set; }
        public DbSet<Models> Models { get; set; }
        public DbSet<Variants> Variants { get; set; }
        public DbSet<AuditTypes> AuditTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Plants> Plants { get; set; }
        public DbSet<ZoneOrStations> ZoneOrStations { get; set; }
        public DbSet<Checkpoints> Checkpoints { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<ScheduleJob> ScheduleJob { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Logger> Logger { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(ConfigHelper.config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            //builder.Entity<CheckpointClasses>().ToTable($"tbl{nameof(CPClass)}");
            //builder.Entity<CPDeviation>().ToTable($"tbl{nameof(CPDeviation)}");
            //builder.Entity<Auditor>().ToTable($"tbl{nameof(Auditor)}");
            //builder.Entity<Email>().ToTable($"tbl{nameof(Email)}");
            //builder.Entity<FaultGroups>().ToTable($"tbl{nameof(FaultGroup)}");
            //builder.Entity<Shift>().ToTable($"tbl{nameof(Shift)}");
            //builder.Entity<Model>().ToTable($"tbl{nameof(Model)}");
            //builder.Entity<Variant>().ToTable($"tbl{nameof(Variant)}");
            //builder.Entity<AuditType>().ToTable($"tbl{nameof(AuditType)}");
            //builder.Entity<Products>().ToTable($"tbl{nameof(Product)}");
            //builder.Entity<Plant>().ToTable($"tbl{nameof(Plant)}");
            //builder.Entity<ZoneOrStations>().ToTable($"tbl{nameof(Zone)}");
            //builder.Entity<Checkpoints>().ToTable($"tbl{nameof(Checkpoints)}");
            //builder.Entity<Category>().ToTable($"tbl{nameof(Category)}");
            builder.Entity<Role>().ToTable($"{nameof(Role)}");
            //builder.Entity<ActivityLog>().ToTable($"tbl{nameof(ActivityLog)}");
            //builder.Entity<ScheduleJob>().ToTable($"tbl{nameof(ScheduleJob)}");
            builder.Entity<Users>().ToTable($"{nameof(Users)}");
            //builder.Entity<Menu>().ToTable($"tbl{nameof(Menu)}");
            //builder.Entity<RefreshToken>().ToTable($"tbl{nameof(RefreshToken)}");
            //builder.Entity<Permission>().ToTable($"tbl{nameof(Permission)}");
            builder.Entity<Users>().Property(x => x.UserId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
            builder.Entity<Role>().Property(x => x.RoleId).Metadata.SetAfterSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        }
    }
}
