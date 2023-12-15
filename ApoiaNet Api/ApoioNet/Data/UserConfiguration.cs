namespace ApoioNet.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    { 

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USUARIO");
            builder.HasKey(a => a.CPF);

            builder
                .Property(a => a.CPF)
                .HasColumnName("USER_CPF")
                .HasColumnType("CHAR(11)");

            builder
                .Property(a => a.Email)
                .HasColumnName("USER_EMAIL")
                .HasColumnType("VARCHAR(50)");

            builder
                .Property(a => a.Senha)
                .HasColumnName("USER_SENHA")
                .HasColumnType("VARCHAR(MAX)");

        }
    }
}
