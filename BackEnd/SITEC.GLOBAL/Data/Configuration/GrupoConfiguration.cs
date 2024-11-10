using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.ToTable("Grupo");

            builder.HasKey(x => x.GrupoId);

            builder.Property(x => x.GrupoId)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(x => x.Maestro)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MaestroId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Materias)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.MateriaId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Alumno)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.AlumnoId)
                .OnDelete(DeleteBehavior.Restrict);


            //builder.HasData(
            //    new Grupo
            //    {
            //        GrupoId = 1,
            //        AlumnoId = 20211848,
            //        MaestroId = 1,
            //        MateriaId = 1,
            //    },
            //    new Grupo
            //    {
            //        GrupoId = 2,
            //        AlumnoId = 1,
            //        MaestroId = 1,
            //        MateriaId = 1,
            //    },
            //    new Grupo
            //    {
            //        GrupoId = 3,
            //        AlumnoId = 2,
            //        MaestroId = 1,
            //        MateriaId = 1,
            //    },
            //    new Grupo
            //    {
            //        GrupoId = 4,
            //        AlumnoId = 3,
            //        MaestroId = 1,
            //        MateriaId = 1,
            //    });
        }
    }
}
