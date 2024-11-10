﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SITEC.GLOBAL.Data.Context;

#nullable disable

namespace SITEC.GLOBAL.Migrations
{
    [DbContext(typeof(SitecDBContext))]
    [Migration("20240511013156_Tokens")]
    partial class Tokens
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Alumno", b =>
                {
                    b.Property<int>("NumeroControl")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NumeroControl"));

                    b.Property<string>("Carrera")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("CreditosTotales")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("CreditosUsados")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SemestreId")
                        .HasColumnType("int");

                    b.Property<int>("TokensTotales")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("TokensUsados")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("NumeroControl");

                    b.HasIndex("SemestreId");

                    b.ToTable("Alumnos", "dbo");

                    b.HasData(
                        new
                        {
                            NumeroControl = 20211848,
                            Carrera = "Ing. Sistemas Computacionales",
                            CreditosTotales = 1,
                            CreditosUsados = 0,
                            Email = "l20211848@tectijuana.edu.mx",
                            Name = "Sergio Rosario Sobrado Espinoza",
                            Password = "Sobrado18",
                            SemestreId = 8,
                            TokensTotales = 0,
                            TokensUsados = 0
                        },
                        new
                        {
                            NumeroControl = 1,
                            Carrera = "Ing. Sistemas Computacionales",
                            CreditosTotales = 1,
                            CreditosUsados = 0,
                            Email = "1@tectijuana.edu.mx",
                            Name = "Edgar Uriel Rosales Espinoza",
                            Password = "12345",
                            SemestreId = 8,
                            TokensTotales = 0,
                            TokensUsados = 0
                        },
                        new
                        {
                            NumeroControl = 2,
                            Carrera = "Ing. Sistemas Computacionales",
                            CreditosTotales = 1,
                            CreditosUsados = 0,
                            Email = "2@tectijuana.edu.mx",
                            Name = "Alan Jimenez Herrera",
                            Password = "12345",
                            SemestreId = 8,
                            TokensTotales = 0,
                            TokensUsados = 0
                        },
                        new
                        {
                            NumeroControl = 3,
                            Carrera = "Ing. Sistemas Computacionales",
                            CreditosTotales = 1,
                            CreditosUsados = 0,
                            Email = "3tectijuana.edu.mx",
                            Name = "Yahir Emiliano Gonzalez Dominguez",
                            Password = "12345",
                            SemestreId = 8,
                            TokensTotales = 0,
                            TokensUsados = 0
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Grupo", b =>
                {
                    b.Property<int>("GrupoId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GrupoId"));

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.Property<int>("MaestroId")
                        .HasColumnType("int");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.HasKey("GrupoId");

                    b.HasIndex("AlumnoId");

                    b.HasIndex("MaestroId");

                    b.HasIndex("MateriaId");

                    b.ToTable("Grupo", "dbo");

                    b.HasData(
                        new
                        {
                            GrupoId = 1,
                            AlumnoId = 20211848,
                            MaestroId = 1,
                            MateriaId = 1
                        },
                        new
                        {
                            GrupoId = 2,
                            AlumnoId = 1,
                            MaestroId = 1,
                            MateriaId = 1
                        },
                        new
                        {
                            GrupoId = 3,
                            AlumnoId = 2,
                            MaestroId = 1,
                            MateriaId = 1
                        },
                        new
                        {
                            GrupoId = 4,
                            AlumnoId = 3,
                            MaestroId = 1,
                            MateriaId = 1
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Maestro", b =>
                {
                    b.Property<int>("MaestroId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaestroId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MaestroId");

                    b.ToTable("Maestro", "dbo");

                    b.HasData(
                        new
                        {
                            MaestroId = 1,
                            Name = "Alma Sofia"
                        },
                        new
                        {
                            MaestroId = 2,
                            Name = "Sergio Magdaleno"
                        },
                        new
                        {
                            MaestroId = 3,
                            Name = "El de IA"
                        },
                        new
                        {
                            MaestroId = 4,
                            Name = "Miguel Angel"
                        },
                        new
                        {
                            MaestroId = 5,
                            Name = "Miramontes"
                        },
                        new
                        {
                            MaestroId = 6,
                            Name = "Jose Jonathan"
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Materia", b =>
                {
                    b.Property<int>("MateriaId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MateriaId"));

                    b.Property<TimeOnly>("HoraFinal")
                        .HasMaxLength(500)
                        .HasColumnType("time");

                    b.Property<TimeOnly>("HorarioInicio")
                        .HasMaxLength(500)
                        .HasColumnType("time");

                    b.Property<bool>("IsGlobal")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("MateriaId");

                    b.ToTable("Materia", "dbo");

                    b.HasData(
                        new
                        {
                            MateriaId = 1,
                            HoraFinal = new TimeOnly(14, 0, 0),
                            HorarioInicio = new TimeOnly(13, 0, 0),
                            IsGlobal = true,
                            Name = "Gestion de proyectos de softweare",
                            Serie = "SC-GP24"
                        },
                        new
                        {
                            MateriaId = 2,
                            HoraFinal = new TimeOnly(16, 0, 0),
                            HorarioInicio = new TimeOnly(15, 0, 0),
                            IsGlobal = true,
                            Name = "Inteligencia Artificial",
                            Serie = "SC-IA24"
                        },
                        new
                        {
                            MateriaId = 3,
                            HoraFinal = new TimeOnly(17, 0, 0),
                            HorarioInicio = new TimeOnly(16, 0, 0),
                            IsGlobal = true,
                            Name = "Taller De Investigación",
                            Serie = "SC-TI24"
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.MateriasAlumno", b =>
                {
                    b.Property<int>("MateriaAlumnoId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MateriaAlumnoId"));

                    b.Property<bool>("Cursada")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroControl")
                        .HasColumnType("int");

                    b.HasKey("MateriaAlumnoId");

                    b.HasIndex("MateriaId");

                    b.HasIndex("NumeroControl");

                    b.ToTable("MateriasAlumnos", "dbo");
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Semestre", b =>
                {
                    b.Property<int>("SemestreId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemestreId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("SemestreId");

                    b.ToTable("Semestre", "dbo");

                    b.HasData(
                        new
                        {
                            SemestreId = 1,
                            Name = "Primer Semestre"
                        },
                        new
                        {
                            SemestreId = 2,
                            Name = "Segundo Semestre"
                        },
                        new
                        {
                            SemestreId = 3,
                            Name = "Tercer Semestre"
                        },
                        new
                        {
                            SemestreId = 4,
                            Name = "Cuarto Semestre"
                        },
                        new
                        {
                            SemestreId = 5,
                            Name = "Quinto Semestre"
                        },
                        new
                        {
                            SemestreId = 6,
                            Name = "Sexto Semestre"
                        },
                        new
                        {
                            SemestreId = 7,
                            Name = "Septimo Semestre"
                        },
                        new
                        {
                            SemestreId = 8,
                            Name = "Octavo Semestre"
                        },
                        new
                        {
                            SemestreId = 9,
                            Name = "Noveno Semestre"
                        },
                        new
                        {
                            SemestreId = 10,
                            Name = "Decimo Semestre"
                        },
                        new
                        {
                            SemestreId = 11,
                            Name = "Onceavo Semestre"
                        },
                        new
                        {
                            SemestreId = 12,
                            Name = "Doceavo Semestre"
                        },
                        new
                        {
                            SemestreId = 13,
                            Name = "Terceavo Semestre"
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.SemestreMatetrias", b =>
                {
                    b.Property<int>("SemestreMateriasId")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemestreMateriasId"));

                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("SemestreId")
                        .HasColumnType("int");

                    b.HasKey("SemestreMateriasId");

                    b.HasIndex("MateriaId");

                    b.HasIndex("SemestreId");

                    b.ToTable("SemestreMateria", "dbo");

                    b.HasData(
                        new
                        {
                            SemestreMateriasId = 1,
                            MateriaId = 1,
                            SemestreId = 8
                        },
                        new
                        {
                            SemestreMateriasId = 12,
                            MateriaId = 2,
                            SemestreId = 8
                        },
                        new
                        {
                            SemestreMateriasId = 3,
                            MateriaId = 3,
                            SemestreId = 8
                        });
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Alumno", b =>
                {
                    b.HasOne("SITEC.GLOBAL.Domain.Models.Semestre", "Semestre")
                        .WithMany()
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Semestre");
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.Grupo", b =>
                {
                    b.HasOne("SITEC.GLOBAL.Domain.Models.Alumno", "Alumno")
                        .WithMany()
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SITEC.GLOBAL.Domain.Models.Maestro", "Maestro")
                        .WithMany()
                        .HasForeignKey("MaestroId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SITEC.GLOBAL.Domain.Models.Materia", "Materias")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Maestro");

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.MateriasAlumno", b =>
                {
                    b.HasOne("SITEC.GLOBAL.Domain.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SITEC.GLOBAL.Domain.Models.Alumno", "Alumno")
                        .WithMany()
                        .HasForeignKey("NumeroControl")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("SITEC.GLOBAL.Domain.Models.SemestreMatetrias", b =>
                {
                    b.HasOne("SITEC.GLOBAL.Domain.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SITEC.GLOBAL.Domain.Models.Semestre", "Semestre")
                        .WithMany()
                        .HasForeignKey("SemestreId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("Semestre");
                });
#pragma warning restore 612, 618
        }
    }
}
