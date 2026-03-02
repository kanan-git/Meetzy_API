using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class CityConfigurations:IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(c => c.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();

        // relations
        builder.HasMany(c => c.Profiles).WithOne(p => p.City).HasForeignKey(p => p.CityId).OnDelete(DeleteBehavior.SetNull);
    }
}
