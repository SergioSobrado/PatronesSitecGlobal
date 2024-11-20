using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.ViewModels
{
    public class AlumnoAdapter
    {
        private readonly Alumno _alumno;

        public AlumnoAdapter (Alumno alumno)
        {
            _alumno = alumno;
        }

        public AlumnoVM ToVM()
        {
            return new AlumnoVM
            {
                NumeroControl = _alumno.NumeroControl,
                Carrera = _alumno.Carrera,
                Name = _alumno.Name,
                Semestre = _alumno.Semestre,
                SemestreId = _alumno.SemestreId,
            };
        }
    }
}
