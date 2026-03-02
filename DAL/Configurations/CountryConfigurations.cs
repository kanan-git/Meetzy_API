using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class CountryConfigurations:IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(c => c.Name).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();
        // builder.Property(c => c.IsoCode).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();

        // relations
        builder.HasMany(c => c.Cities).WithOne(ci => ci.Country).HasForeignKey(ci => ci.CountryId).OnDelete(DeleteBehavior.NoAction);
    }
}
