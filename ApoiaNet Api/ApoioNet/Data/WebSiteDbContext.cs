using Microsoft.EntityFrameworkCore;

public class WebSiteDbContext : DbContext
{
    public WebSiteDbContext(DbContextOptions<WebSiteDbContext> options)
        : base(options)
    {
    }

    public DbSet<Website> Websites { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Website>(entity =>
        {
            entity.ToTable("WebSite"); 
            entity.HasKey(w => w.SiteId);
            entity.Property(w => w.Nome).IsRequired();
            entity.Property(w => w.Tipo).IsRequired();
            entity.Property(w => w.URL).IsRequired();
        });


    }
}
