using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class AuthorDataConf : IEntityTypeConfiguration<AuthorData>
{
    public void Configure(EntityTypeBuilder<AuthorData> builder)
    {
        builder.ToTable("AuthorDatas");
        builder.HasKey(ad => ad.Id);
        builder.Property(ad => ad.Biography).IsRequired();
    }
}