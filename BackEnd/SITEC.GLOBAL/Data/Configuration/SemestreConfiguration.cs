using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Domain.Models;
using SITEC.GLOBAL.Domain.Helpers;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class SemestreConfiguration : IEntityTypeConfiguration<Semestre>
    {
        public void Configure(EntityTypeBuilder<Semestre> builder)
        {
            builder.ToTable("Semestre");

            builder.HasKey(x => x.SemestreId);

            builder.Property(x => x.SemestreId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasData(
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.PrimerSemestre,
                    Name = "Primer Semestre",
                },
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.SegundoSemestre,
                    Name = "Segundo Semestre",
                },
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.TercerSemestre,
                    Name = "Tercer Semestre",
                },
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.CuartoSemestre,
                    Name = "Cuarto Semestre",
                },
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.QuintoSemestre,
                    Name = "Quinto Semestre",
                },
                new Semestre
                {
                    SemestreId = (int)SemestreEnum.SextoSemestre,
                    Name = "Sexto Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.SeptimoSemestre,
                    Name = "Septimo Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.OctavoSemestre,
                    Name = "Octavo Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.NovenoSemestre,
                    Name = "Noveno Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.DecimoSemestre,
                    Name = "Decimo Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.OnceavoSemestre,
                    Name = "Onceavo Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.DoceavoSemestre,
                    Name = "Doceavo Semestre",
                },
                new Semestre
                {SemestreId = (int)SemestreEnum.TreceavoSemestre, 
                    Name = "Terceavo Semestre",
                }
                );
        }
    }
}
