using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEC.GLOBAL.Data.Context
{
    public class SitecDBContext : DbContext
    {
        public SitecDBContext(DbContextOptions<SitecDBContext> options) : base(options) 
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new AlumnoConfigurations());
            modelBuilder.ApplyConfiguration(new MateriaConfiguration());
            modelBuilder.ApplyConfiguration(new MaestroConfiguration());
            modelBuilder.ApplyConfiguration(new SemestreConfiguration());
            modelBuilder.ApplyConfiguration(new GrupoConfiguration());
            modelBuilder.ApplyConfiguration(new SemestreMateriasConfiguration());
            modelBuilder.ApplyConfiguration(new MateriasAlumnoConfiguration());
            modelBuilder.ApplyConfiguration(new RequestConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
