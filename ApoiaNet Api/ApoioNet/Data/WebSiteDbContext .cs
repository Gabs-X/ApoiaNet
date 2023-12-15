using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class WebSiteDbContext : DbContext
{
    public WebSiteDbContext(DbContextOptions<WebSiteDbContext> options)
    : base(options)
    {
    }

    public DbSet<Website> Websites { get; set; } // Substitua "Website" pela sua entidade
}
