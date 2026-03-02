using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class FriendRequestConfigurations:IEntityTypeConfiguration<FriendRequest>
{
    public void Configure(EntityTypeBuilder<FriendRequest> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(fr => fr.Status).IsRequired();
    }
}
