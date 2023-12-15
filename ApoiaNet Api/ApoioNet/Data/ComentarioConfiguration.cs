using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApoioNet.Data
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.ToTable("Comentarios");
            builder.HasKey(a => a.SiteId);

            builder
                .Property(a => a.SiteId)
                .UseIdentityColumn()
                .HasColumnName("idcomentario");


            builder
                .Property(a => a.Email)
                .HasColumnName("email");

            builder
                .Property(a => a.Conteudo)
                .HasColumnName("comentario");

        }
    }
}
