using LegalManagementSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegalManagementSaaS.Infrastructure.Persistence.Configurations
{
    public class LegalCaseConfiguration : IEntityTypeConfiguration<LegalCase>
    {
        public void Configure(EntityTypeBuilder<LegalCase> builder)
        {
            builder.ToTable("LegalCases");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Description)
                .HasMaxLength(1000);

            builder.Property(c => c.ClientName)
                .IsRequired()
                .HasMaxLength(1000);

            builder.Property(c => c.Status)
                .IsRequired()
                .HasConversion<int>(); // Stores enum as integer in DB

            // Configure the private backing field for the collection (DDD Encapsulation)
            builder.HasMany(c => c.Notifications)
                .WithOne()
                .HasForeignKey(n => n.LegalCaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Metadata.FindNavigation(nameof(LegalCase.Notifications))?
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
