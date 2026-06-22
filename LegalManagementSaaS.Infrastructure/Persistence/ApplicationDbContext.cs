using LegalManagementSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LegalManagementSaaS.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LegalCase> LegalCases => Set<LegalCase>();
        public DbSet<LegalNotification> LegalNotifications => Set<LegalNotification>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
