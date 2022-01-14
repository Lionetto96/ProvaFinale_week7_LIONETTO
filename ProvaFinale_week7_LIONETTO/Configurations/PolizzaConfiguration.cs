using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProvaFinale_week7_LIONETTO.Models;

namespace ProvaFinale_week7_LIONETTO
{
    public class PolizzaConfiguration : IEntityTypeConfiguration<Polizza>
    {
        public void Configure(EntityTypeBuilder<Polizza> builder)
        {
            builder.ToTable("Polizza");
            builder.HasKey(p => p.NumeroPolizza);
            builder.Property(p => p.DataStipula).IsRequired();
            builder.Property(p => p.ImportoAssicurazione).IsRequired();
            builder.Property(p => p.RataMensile).IsRequired();
            

            //per gerarchia

            builder.HasDiscriminator<string>("Type")
                .HasValue<RcAuto>("RcAuto")
                .HasValue<Furto>("Furto")
                .HasValue<Vita>("Vita");

            //relazione con Cliente
            builder.HasOne(p => p.Cliente).WithMany(p => p.Polizze).HasForeignKey(p => p.CodiceFiscale).HasConstraintName("FkCliente");
        }
    }
}