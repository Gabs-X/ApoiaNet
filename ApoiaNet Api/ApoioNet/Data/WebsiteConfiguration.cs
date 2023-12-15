using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class WebsiteConfiguration : IEntityTypeConfiguration<Website>
{
    public void Configure(EntityTypeBuilder<Website> builder)
    {
        builder.ToTable("Website");
        builder.HasKey(a => a.SiteId);

        builder
            .Property(a => a.SiteId)
            .UseIdentityColumn()
            .HasColumnName("Siteid")
            .HasColumnType("int");

        builder
            .Property(a => a.Nome)
            .HasColumnName("Nome")
            .HasColumnType("varchar");

        builder
            .Property(a => a.Tipo)
            .HasColumnName("Tipo")
            .HasColumnType("varchar");

        builder
            .Property(a => a.URL)
            .HasColumnName("URL")
            .HasColumnType("varchar");
    }
}
