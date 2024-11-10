using Arch.EntityFrameworkCore.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using SITEC.GLOBAL.Data.Context;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Data.Repository
{
    public class CustomSemestreRepository : Repository<MateriasAlumno>, IRepository<MateriasAlumno>
    {
        public CustomSemestreRepository(SitecDBContext sitecDBContext) : base(sitecDBContext) { }

        public List<SemestreMatetrias> GetMateriasBySemestreId(int semestreId) 
        {
            return _dbContext.Set<SemestreMatetrias>()
                .Include(x => x.Materia)
                .Include(x => x.Semestre)
                .Where(x => x.SemestreId == semestreId)
                .ToList();
        }

        public List<MateriasAlumno> GetMateriasAvailableToStudent(int alumnoId)
        {
            List<MateriasAlumno> materias = _dbContext.Set<MateriasAlumno>()
                .Include(x => x.Materia)
                .Include(x => x.Alumno)
                .Where(x => x.NumeroControl == alumnoId && x.Cursada == 0)
                .ToList();
            return materias;
        }

        public int UpdateMateriasStatus(MateriasAlumno materiasAlumnos)
        {
            try
            {
                UpdateAsync(materiasAlumnos);
                _dbContext.SaveChanges();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        public List<MateriasAlumno> GetMateriasCursandoPorAlumno(int alumnoId)
        {
            List<MateriasAlumno> materias = _dbContext.Set<MateriasAlumno>()
                .Include(x => x.Materia)
                .Include(x => x.Alumno)
                .Include(x => x.Maestro)
                .Where(x => x.NumeroControl == alumnoId && x.Cursada == 2)
                .OrderBy(x => x.Materia.HorarioInicio)
                .ToList();
            return materias;
        }

        public MateriasAlumno GetMateriasDuplicadasSeleccionadas(int materiaId, int numeroControl)
        {
            return _dbContext.Set<MateriasAlumno>()
                .Include(x => x.Materia)
                .Include(x => x.Maestro)
                .Include(x => x.Alumno)
                .Where(x => x.MateriaId == materiaId && x.Cursada != 4 && x.NumeroControl == numeroControl)
                .FirstOrDefault();
        }

        public List<MateriasAlumno> GetMateriasGlobales(int alumnoId)
        {
            return _dbContext.Set<MateriasAlumno>()
                .Include(x => x.Materia)
                .Include(x => x.Maestro)
                .Include(x => x.Alumno)
                .Where(x => x.NumeroControl == alumnoId && x.Cursada == 4)
                .ToList();
        }

        public int SetMateriaAsGlobal(MateriasAlumno materia)
        {
            try
            {
                UpdateAsync(materia);
                _dbContext.SaveChanges();
                return 1;
            }
            catch 
            {
                return 0;
            }
        }
    }
}
