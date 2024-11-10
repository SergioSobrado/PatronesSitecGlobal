using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Data.Context;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Repository
{
    public class CustomAlumnoRepository : Repository<Alumno>, IRepository<Alumno>
    {
        public CustomAlumnoRepository(SitecDBContext dBContext) : base(dBContext) { }

        public Alumno GetAlumnoByAlumnoId(int AlumnoId)
        {
            return _dbContext.Set<Alumno>()
                .Include(x => x.Semestre)
                .FirstOrDefault(x => x.NumeroControl == AlumnoId);
        }

        public Alumno LoggedUser(int numeroControl, string Password)
        {
            return _dbContext.Set<Alumno>()
                .Include(x => x.Semestre)
                .Where(x => x.NumeroControl == numeroControl && x.Password == Password)
                .FirstOrDefault();
        }

        public List<MateriasAlumno> AlumnoMaterias(int numeroControl) 
        {
            return _dbContext.Set<MateriasAlumno>()
                .Include(x => x.Materia)
                .Include(x => x.Alumno)
                .Where(x => x.NumeroControl == numeroControl)
                .ToList();
        }
    }
}
