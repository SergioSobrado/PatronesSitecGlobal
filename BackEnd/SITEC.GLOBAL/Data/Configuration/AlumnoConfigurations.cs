using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SITEC.GLOBAL.Domain.Helpers;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Configuration
{
    public class AlumnoConfigurations : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.ToTable("Alumnos");

            builder.HasKey(x => x.NumeroControl);

            builder.Property(x => x.NumeroControl)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.Password) 
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.Carrera)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(x => x.CreditosTotales)
               .IsRequired()
               .HasMaxLength(50);
            builder.Property(x => x.CreditosUsados)
               .IsRequired()
               .HasMaxLength(50);
            builder.Property(x => x.TokensUsados)
               .IsRequired()
               .HasMaxLength(50);
            builder.Property(x => x.TokensTotales)
               .IsRequired()
               .HasMaxLength(50);

            builder.Property(x => x.IsAdmin)
               .IsRequired();

            builder.HasOne(x => x.Semestre)
                .WithMany()
                .IsRequired()
                .HasForeignKey(x => x.SemestreId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasData(
                new Alumno {
                    NumeroControl = 20211848,
                    Name = "Sergio Rosario Sobrado Espinoza",
                    Carrera = "Ing. Sistemas Computacionales",
                    CreditosTotales = 1,
                    CreditosUsados = 0,
                    Email = "l20211848@tectijuana.edu.mx",
                    Password = "Sobrado18",
                    SemestreId = (int)SemestreEnum.OctavoSemestre,
                    IsAdmin = false,
                },
                new Alumno
                {
                    NumeroControl = 1,
                    Name = "Edgar Uriel Rosales Espinoza",
                    Carrera = "Ing. Sistemas Computacionales",
                    CreditosTotales = 1,
                    CreditosUsados = 0,
                    Email = "1@tectijuana.edu.mx",
                    Password = "12345",
                    SemestreId = (int)SemestreEnum.OctavoSemestre,
                    IsAdmin = false,
                },
                new Alumno
                {
                    NumeroControl = 2,
                    Name = "Alan Jimenez Herrera",
                    Carrera = "Ing. Sistemas Computacionales",
                    CreditosTotales = 1,
                    CreditosUsados = 0,
                    Email = "2@tectijuana.edu.mx",
                    Password = "12345",
                    SemestreId = (int)SemestreEnum.OctavoSemestre,
                    IsAdmin = false,
                },
                new Alumno
                {
                    NumeroControl = 3,
                    Name = "Yahir Emiliano Gonzalez Dominguez",
                    Carrera = "Ing. Sistemas Computacionales",
                    CreditosTotales = 1,
                    CreditosUsados = 0,
                    Email = "3tectijuana.edu.mx",
                    Password = "12345",
                    SemestreId = (int)SemestreEnum.OctavoSemestre,
                    IsAdmin = false,
                },
                new Alumno
                {
                    NumeroControl = 100,
                    Name = "Admin",
                    Carrera = "Departamento",
                    CreditosTotales = 1,
                    CreditosUsados = 0,
                    Email = "admin@tectijuana.edu.mx",
                    Password = "12345",
                    SemestreId = (int)SemestreEnum.OctavoSemestre,
                    IsAdmin = true,
                });
        }
    }
}
