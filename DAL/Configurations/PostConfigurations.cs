using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class PostConfigurations:IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(p => p.TextContent).HasColumnType(SqlDbType.NVarChar.ToString()).HasMaxLength(256).IsRequired();
        builder.Property(p => p.Location).HasMaxLength(40);

        // relations
        builder.HasMany(p => p.Comments).WithOne(c => c.Post).HasForeignKey(c => c.PostId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.PostReactions).WithOne(pr => pr.Post).HasForeignKey(pr => pr.PostId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.MediaFiles).WithOne(mf => mf.Post).HasForeignKey(mf => mf.PostId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(p => p.Hashtag).WithMany(h => h.Posts);
    }
}
