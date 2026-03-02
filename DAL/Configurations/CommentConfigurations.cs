using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Entities.Concrete;
using System.Data;

namespace DAL.Configurations;

public class CommentConfigurations:IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // main
        builder.Property<Guid>("Id");
        // builder.Property(c => c.Text).HasMaxLength(120).HasColumnType(SqlDbType.NVarChar.ToString()).IsRequired();

        // relations
        builder.HasMany(c => c.Replies).WithOne(c => c.ParentComment).HasForeignKey(c => c.ParentCommentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(c => c.CommentReactions).WithOne(cr => cr.Comment).HasForeignKey(cr => cr.CommentId).OnDelete(DeleteBehavior.Restrict);
    }
}
