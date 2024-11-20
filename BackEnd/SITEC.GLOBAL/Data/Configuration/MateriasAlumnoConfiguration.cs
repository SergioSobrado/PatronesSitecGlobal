using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Domain.Helpers;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class MateriasAlumnoConfiguration : IEntityTypeConfiguration<MateriasAlumno>
    {
        public void Configure(EntityTypeBuilder<MateriasAlumno> builder)
        {
            builder.ToTable("MateriasAlumnos");

            builder.HasKey(x => x.MateriaAlumnoId);

            builder.Property(x => x.MateriaAlumnoId)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Cursada)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Alumno)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.NumeroControl)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Materia)
              .WithMany()
              .IsRequired()
              .HasForeignKey(x => x.MateriaId)
              .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(x => x.Maestro)
              .WithMany()
              .IsRequired()
              .HasForeignKey(x => x.MaestroId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
