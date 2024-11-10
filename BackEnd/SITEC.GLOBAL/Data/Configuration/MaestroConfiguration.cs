using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class MaestroConfiguration : IEntityTypeConfiguration<Maestro> 
    {
        public void Configure(EntityTypeBuilder<Maestro> builder)
        {
            builder.ToTable("Maestro");

            builder.HasKey(x => x.MaestroId);

            builder.Property(x => x.MaestroId)
                
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

           
            builder.HasData(
                new Maestro { MaestroId = 1, Name = "Alma Sofia", },
                new Maestro { MaestroId = 2, Name = "Sergio Magdaleno", },
                new Maestro { MaestroId = 3, Name = "El de IA", },
                new Maestro { MaestroId = 4, Name = "Miguel Angel", },
                new Maestro { MaestroId = 5, Name = "Miramontes", },
                new Maestro { MaestroId = 6, Name = "Jose Jonathan", }
                );
        }
    }
}
