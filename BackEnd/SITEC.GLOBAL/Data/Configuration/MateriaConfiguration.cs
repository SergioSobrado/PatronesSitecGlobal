using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.ToTable("Materia");

            builder.HasKey(x => x.MateriaId);

            builder.Property(x => x.MateriaId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.IsGlobal)
                .IsRequired();

            builder.Property(x => x.Serie)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.HorarioInicio)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.HoraFinal)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(x => x.Creditos)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasData(
                new
                {
                    MateriaId = 1,
                    HoraFinal = new TimeOnly(14, 0, 0),
                    HorarioInicio = new TimeOnly(13, 0, 0),
                    IsGlobal = true,
                    Name = "Gestion de proyectos de softweare",
                    Serie = "SC-GP24",
                    Creditos = 5
                },
                new
                {
                    MateriaId = 2,
                    HoraFinal = new TimeOnly(16, 0, 0),
                    HorarioInicio = new TimeOnly(15, 0, 0),
                    IsGlobal = true,
                    Name = "Inteligencia Artificial",
                    Serie = "SC-IA24",
                    Creditos = 5

                },
                new
                {
                    MateriaId = 3,
                    HoraFinal = new TimeOnly(17, 0, 0),
                    HorarioInicio = new TimeOnly(16, 0, 0),
                    IsGlobal = true,
                    Name = "Taller De Investigación",
                    Serie = "SC-TI24",
                    Creditos = 5
                });
        }
    }
}
