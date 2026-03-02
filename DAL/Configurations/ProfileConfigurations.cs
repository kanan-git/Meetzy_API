using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class ProfileConfigurations:IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(p => p.Addressline).HasMaxLength(40).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
        // builder.Property(p => p.Bio).HasMaxLength(256).HasColumnType(SqlDbType.NVarChar.ToString());
        // builder.Property(p => p.CoverPictureUrl).HasColumnType(SqlDbType.VarChar.ToString());
        // builder.Property(p => p.CurrentStatus).IsRequired();
        // builder.Property(p => p.FeedPageUrl).IsRequired();
        // builder.Property(p => p.IpV4Address).HasMaxLength(15).HasColumnType(SqlDbType.VarChar.ToString());
        // builder.Property(p => p.IpV6Address).HasMaxLength(39).HasColumnType(SqlDbType.VarChar.ToString());
        // builder.Property(p => p.IsPrivate).HasColumnType(SqlDbType.TinyInt.ToString()).IsRequired();
        // builder.Property(p => p.ProfilePictureUrl).HasColumnType(SqlDbType.VarChar.ToString());

        // relations
        // builder.HasOne(p => p.ProfileImage).WithOne(mf => mf.ProfileImageOwner).
        builder.HasMany(p => p.Activities).WithOne(al => al.Profile).HasForeignKey(al => al.ProfileId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.Posts).WithOne(p => p.Profile).HasForeignKey(p => p.ProfileId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(p => p.Comments).WithOne(c => c.Profile).HasForeignKey(p => p.ProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.MessagesSent).WithOne(m => m.SenderProfile).HasForeignKey(p => p.SenderProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.MessagesReceived).WithOne(m => m.ReceiverProfile).HasForeignKey(p => p.ReceiverProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Notifications).WithOne(n => n.TargetProfile).HasForeignKey(p => p.TargetProfileId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.FriendsListsInitiated).WithOne(fl => fl.Profile).HasForeignKey(p => p.ProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.FriendsListsReceived).WithOne(fl => fl.Friend).HasForeignKey(p => p.FriendId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.FriendRequestsSent).WithOne(fr => fr.SenderProfile).HasForeignKey(p => p.SenderProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.FriendRequestsReceived).WithOne(fr => fr.ReceiverProfile).HasForeignKey(p => p.ReceiverProfileId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.PostReactions).WithOne(pr => pr.Profile).HasForeignKey(p => p.ProfileId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.CommentReactions).WithOne(cr => cr.Profile).HasForeignKey(p => p.ProfileId).OnDelete(DeleteBehavior.NoAction);
    }
}
