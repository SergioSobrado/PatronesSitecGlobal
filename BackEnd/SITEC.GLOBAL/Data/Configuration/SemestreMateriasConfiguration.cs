using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class SemestreMateriasConfiguration : IEntityTypeConfiguration<SemestreMatetrias>
    {
        public void Configure(EntityTypeBuilder<SemestreMatetrias> builder)
        {
            builder.ToTable("SemestreMateria");

            builder.HasKey(x => x.SemestreMateriasId);

            builder.Property(x => x.SemestreMateriasId)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Materia)
                .WithMany()
                .HasForeignKey(x => x.MateriaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Semestre)
                .WithMany()
                .HasForeignKey(x => x.SemestreId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new SemestreMatetrias
                {
                    SemestreMateriasId = 1,
                    SemestreId = 8,
                    MateriaId = 2,
                },
                new SemestreMatetrias
                {
                    SemestreMateriasId = 12,
                    SemestreId = 8,
                    MateriaId = 2,
                },
                new SemestreMatetrias
                {
                    SemestreMateriasId = 3,
                    SemestreId = 8,
                    MateriaId = 3,
                }
                );
        }
    }
}
