using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class PostReactionConfigurations:IEntityTypeConfiguration<PostReaction>
{
    public void Configure(EntityTypeBuilder<PostReaction> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(pr => pr.ReactionType).IsRequired();
    }
}
