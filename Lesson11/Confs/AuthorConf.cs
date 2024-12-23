using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuthorConf : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        
        builder.HasOne(a => a.AuthorData)
               .WithOne(ad => ad.Author)
               .HasForeignKey<AuthorData>(ad => ad.AuthorId);

        builder.Property(a => a.DateOfBirth).HasColumnType("date").HasMaxLength(10);
    }
}