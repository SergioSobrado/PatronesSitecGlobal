using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SITEC.GLOBAL.BussinessLogic.Messages;
using SITEC.GLOBAL.BussinessLogic.Services;
using SITEC.GLOBAL.BussinessLogic.ViewModels;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly MateriaService _materiaService;

        public MateriasController(MateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        [Route("GetMateriasBySemestreId")]
        public ResponseBase<List<SemestreMatetrias>> GetMateriasBySemestreId(int semestreId)
        {
            return _materiaService.GetMateriasBySemestreId(semestreId);
        }

        [HttpGet]
        [Route("GetMateriasAvailableToStudent")]
        public ResponseBase<List<MateriasAlumno>> GetMateriasAvailableToStudent(int alumnoId)
        {
            return _materiaService.GetMateriasAvailableToStudent(alumnoId);
        }

        [HttpPost]
        [Route("NewMateriasToStudent")]
        public ResponseBase<int> NewMateriasToStudent(List<MateriasAlumnoVM> materiasAlumnos)
        {
            return _materiaService.NewMateriasToStudent(materiasAlumnos);
        }

        [HttpGet]
        [Route("GetMateriasCursandoPorAlumno")]
        public ResponseBase<List<MateriasAlumno>> GetMateriasCursandoPorAlumno(int alumnoId)
        {
            return _materiaService.GetMateriasCursandoPorAlumno(alumnoId);
        }

        [HttpPost]
        [Route("GetMateriasDuplicadasSeleccionadas")]
        public ResponseBase<List<MateriasAlumno>> GetMateriasDuplicadasSeleccionadas(List<MateriasAlumno> materias)
        {
            return _materiaService.GetMateriasDuplicadasSeleccionadas(materias);
        }


        [HttpPost]
        [Route("SetMateriaAsGlobal")]
        public ResponseBase<int> SetMateriaAsGlobal(MateriasAlumnoVM materias)
        {
            return _materiaService.SetMateriaAsGlobal(materias);
        }


        [HttpGet]
        [Route("GetMateriasGlobales")]
        public ResponseBase<List<MateriasAlumno>> GetMateriasGlobales(int alumnoId)
        {
            return _materiaService.GetMateriasGlobales(alumnoId);
        }
    }
}
