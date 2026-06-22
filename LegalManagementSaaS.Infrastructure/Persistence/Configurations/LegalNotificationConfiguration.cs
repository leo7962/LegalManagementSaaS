using LegalManagementSaaS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LegalManagementSaaS.Infrastructure.Persistence.Configurations
{
    public class LegalNotificationConfiguration : IEntityTypeConfiguration<LegalNotification>
    {
        public void Configure(EntityTypeBuilder<LegalNotification> builder)
        {
            builder.ToTable("LegalNotifications");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Message)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(c => c.CreatedAt)
                .IsRequired();
        }
    }
}
