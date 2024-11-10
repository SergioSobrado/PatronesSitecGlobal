using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SITEC.GLOBAL.BussinessLogic.Messages;
using SITEC.GLOBAL.BussinessLogic.Services;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoService _service;
        public AlumnoController(AlumnoService alumnoService) {
            _service = alumnoService;
        }
        [HttpGet]
        [Route("GetAlumnoByNumeroDeControl")]
        public ResponseBase<Alumno> GetAlumnoByNumeroDeControl(int numeroControl)
        {
            return _service.GetAlumnoByAlumnoId(numeroControl);
        }

        [HttpGet]
        [Route("Login")] 
        public ResponseBase<Alumno> GetLoggedUser(int numeroControl, string password)
        {
            return _service.GetLoggedUser(numeroControl, password);

        }
    }   
}
