using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaFinale_week7_LIONETTO.Models;

namespace ProvaFinale_week7_LIONETTO
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.CodiceFiscale);
            builder.Property(c => c.CodiceFiscale).IsRequired().HasMaxLength(16).IsFixedLength(true);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Cognome).IsRequired().HasMaxLength(20);
            builder.Property(c=>c.Indirizzo).IsRequired().HasMaxLength(50);

            //relazione con Polizza 
            builder.HasMany(c => c.Polizze).WithOne(c => c.Cliente).HasForeignKey(c => c.CodiceFiscale);
        }
    }
}