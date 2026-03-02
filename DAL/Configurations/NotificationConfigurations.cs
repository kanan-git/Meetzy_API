using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class NotificationConfigurations:IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(n => n.Info).IsRequired();
        builder.Property(n => n.IsRead).IsRequired();
    }
}
