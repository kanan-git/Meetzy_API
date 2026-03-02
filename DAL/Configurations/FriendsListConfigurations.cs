using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class FriendsListConfigurations:IEntityTypeConfiguration<FriendsList>
{
    public void Configure(EntityTypeBuilder<FriendsList> builder)
    {
        // main
        builder.Property<Guid>("Id");

        // relations
        builder.HasOne(fl => fl.Profile).WithMany(p => p.FriendsListsInitiated).HasForeignKey(fl => fl.ProfileId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(fl => fl.Friend).WithMany(p => p.FriendsListsReceived).HasForeignKey(fl => fl.FriendId).OnDelete(DeleteBehavior.Restrict);
    }
}
