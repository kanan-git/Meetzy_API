using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class MediaFileConfigurations:IEntityTypeConfiguration<MediaFile>
{
    public void Configure(EntityTypeBuilder<MediaFile> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(mf => mf.FileName).IsRequired();
        // builder.Property(mf => mf.FilePath).IsRequired();
        // builder.Property(mf => mf.FileType).IsRequired();

        // relation
        builder.HasOne(p => p.ProfileImageOwner).WithOne(mf => mf.ProfileImage).HasForeignKey<Profile>(p => p.ProfileImageId).OnDelete(DeleteBehavior.NoAction);
    }
}
