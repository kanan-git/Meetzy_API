using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class ActivityLogConfigurations:IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(al => al.Action).IsRequired();
        builder.Property(al => al.Details);
        builder.Property(al => al.IpV4Address).HasMaxLength(15);
        builder.Property(al => al.IpV6Address).HasMaxLength(39);
    }
}
