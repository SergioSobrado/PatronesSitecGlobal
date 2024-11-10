using Microsoft.AspNetCore.Http.HttpResults;
using SITEC.GLOBAL.BussinessLogic.Messages;
using SITEC.GLOBAL.Data.Repository;
using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.Services
{
    public class AlumnoService
    {
        private readonly CustomAlumnoRepository _customAlumnoRepository;
        public AlumnoService(CustomAlumnoRepository customAlumnoRepository)
        {
            _customAlumnoRepository = customAlumnoRepository;
        }
        public ResponseBase<Alumno> GetAlumnoByAlumnoId(int alumnoId)
        {
            ResponseBase<Alumno> result = new();
            result.Message = "Conectado Correctamente";
            result.Result = _customAlumnoRepository.GetAlumnoByAlumnoId(alumnoId);
            result.Type = ResponseType.Success;
            return result;
        }
        public ResponseBase<Alumno> GetLoggedUser(int numeroControl, string password)
        {
            ResponseBase<Alumno> result = new();
            result.Result = _customAlumnoRepository.LoggedUser(numeroControl, password);
            if(result.Result != null) 
            {
                if(result.Result.NumeroControl > 0)
                {
                    result.Type = ResponseType.Success;
                    result.Message = "Usuario Encotrado";
                }
                else
                {
                    result.Type = ResponseType.Warning;
                    result.Message = "Usuario no encontrado";
                }
            }
            else
            {
                result.Type = ResponseType.Error;
                result.Message = "Hubo un problema al intentar loggearte";
            }
            return result;
        }
    }
}
