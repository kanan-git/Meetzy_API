using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class ChatConfigurations:IEntityTypeConfiguration<Chat>
{
    public void Configure(EntityTypeBuilder<Chat> builder)
    {
        // main
        builder.Property<Guid>("Id");

        // relations
        builder.HasMany(c => c.Messages).WithOne(m => m.Chat).HasForeignKey(m => m.ChatId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.ProfileNo1).WithMany().HasForeignKey(c => c.ProfileNo1Id).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.ProfileNo2).WithMany().HasForeignKey(c => c.ProfileNo2Id).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(c => c.Messages).WithOne(m => m.Chat).HasForeignKey(m => m.ChatId).OnDelete(DeleteBehavior.Cascade);
    }
}
