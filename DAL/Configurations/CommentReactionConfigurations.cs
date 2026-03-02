using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;

namespace DAL.Configurations;

public class CommentReactionConfigurations:IEntityTypeConfiguration<CommentReaction>
{
    public void Configure(EntityTypeBuilder<CommentReaction> builder)
    {
        // main
        builder.Property<Guid>("Id");
        builder.Property(cr => cr.ReactionType).IsRequired();
    }
}
