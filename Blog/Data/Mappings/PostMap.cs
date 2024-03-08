using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // Table
        builder.ToTable("Post");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        // Indexes
        builder.HasIndex(x => x.Slug, "IX_Post_Slug")
            .IsUnique();

        // Properties
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnName("Title")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.LastUpdateDate)
            .IsRequired()
            .HasColumnName("LastUpdateDate")
            .HasColumnType("SMALLDATETIME")
            .HasMaxLength(60)
            // .HasDefaultValueSql("GETDATE()");
            .HasDefaultValue(DateTime.Now.ToUniversalTime());

        // Relationships
        builder
            .HasOne(x => x.Category)
            .WithMany(x => x.Posts)
            .HasConstraintName("FK_Post_Category")
            .OnDelete(DeleteBehavior.Cascade);
    }
}