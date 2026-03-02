using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class HashtagConfigurations:IEntityTypeConfiguration<Hashtag>
{
    public void Configure(EntityTypeBuilder<Hashtag> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(h => h.TagValue).IsRequired();

        // relations
        builder.HasMany(h => h.Posts).WithMany(p => p.Hashtag);
    }
}
