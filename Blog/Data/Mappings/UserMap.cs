using Blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Table
        builder.ToTable("User");

        // Primary Key
        builder.HasKey(x => x.Id);

        // Identity
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        // Properties
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Slug)
            .IsRequired()
            .HasColumnName("Slug")
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Bio);
        builder.Property(x => x.Email);
        builder.Property(x => x.Image);
        builder.Property(x => x.PasswordHash);

        // Indexes
        builder.HasIndex(x => x.Slug, "IX_User_Slug")
            .IsUnique();

        // Relationships
        builder.HasMany(x => x.Posts)
            .WithOne(x => x.Author)
            // .HasForeignKey(x => x.AuthorId)
            .HasConstraintName("FK_Post_User")
            .OnDelete(DeleteBehavior.Cascade);
    }
}