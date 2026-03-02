using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class MessageConfigurations:IEntityTypeConfiguration<Message>
{
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(m => m.TextContent).IsRequired();
        builder.Property(m => m.IsRead).IsRequired();

        // relations
        builder.HasMany(m => m.MediaFiles).WithOne(mf => mf.Message).HasForeignKey(mf => mf.MessageId).OnDelete(DeleteBehavior.Cascade);
    }
}
