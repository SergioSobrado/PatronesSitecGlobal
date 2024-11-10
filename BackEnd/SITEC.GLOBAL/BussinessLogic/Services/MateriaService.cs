using SITEC.GLOBAL.BussinessLogic.Messages;
using SITEC.GLOBAL.BussinessLogic.ViewModels;
using SITEC.GLOBAL.Data.Repository;
using SITEC.GLOBAL.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel;

namespace SITEC.GLOBAL.BussinessLogic.Services
{
    public class MateriaService
    {

        private readonly CustomSemestreRepository _customSemestreRepository;
        private readonly CustomAlumnoRepository _customAlumnoRepository;
        public MateriaService(CustomSemestreRepository customSemestreRepository, CustomAlumnoRepository customAlumnoRepository)
        {
            _customSemestreRepository = customSemestreRepository;
            _customAlumnoRepository = customAlumnoRepository;
        }

        public ResponseBase<List<SemestreMatetrias>> GetMateriasBySemestreId(int semestreId)
        {
            ResponseBase<List<SemestreMatetrias>> response = new();
            response.Result = _customSemestreRepository.GetMateriasBySemestreId(semestreId);
            if(response.Result.Count > 0)
            {
                response.Message = "Materias Encontradas";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "No hay materias para ese semestre";
                response.Type = ResponseType.Error;
            }
            return response;

        }

        public ResponseBase<List<MateriasAlumno>> GetMateriasAvailableToStudent(int alumnoId)
        {
            ResponseBase<List<MateriasAlumno>> response = new();
            response.Result = _customSemestreRepository.GetMateriasAvailableToStudent(alumnoId);
            if (response.Result.Count > 0)
            {
                response.Message = "Materias Encontradas";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "No hay materias para ese semestre";
                response.Type = ResponseType.Error;
            }
            return response;
        }

        public ResponseBase<int> NewMateriasToStudent(List<MateriasAlumnoVM> materiasAlumnos)
        {
            ResponseBase<int> response = new();
            MateriasAlumno materiaModel;
            foreach (MateriasAlumnoVM materias in materiasAlumnos)
            {
                materiaModel = new MateriasAlumno
                {
                    MateriaAlumnoId = materias.MateriaAlumnoId,
                    MaestroId = materias.MaestroId,
                    MateriaId = materias.MateriaId,
                    NumeroControl = materias.NumeroControl,
                };
                materiaModel.Cursada = 2;
                response.Result = _customSemestreRepository.UpdateMateriasStatus(materiaModel);
            }

            if (response.Result == 0)
            {
                response.Message = "Materias agregadas correctamente";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "Hubo un error al actualizar las materias";
                response.Type = ResponseType.Error;
            }
            return response;
        }

        public ResponseBase<List<MateriasAlumno>> GetMateriasCursandoPorAlumno(int alumnoId)
        {
            ResponseBase<List<MateriasAlumno>> response = new();
            response.Result = _customSemestreRepository.GetMateriasCursandoPorAlumno(alumnoId);
            if (response.Result.Count > 0)
            {
                response.Message = "Materias Encontradas";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "No hay materias para ese semestre";
                response.Type = ResponseType.Warning;
            }
            return response;
        }

        public ResponseBase<List<MateriasAlumno>> GetMateriasDuplicadasSeleccionadas(List<MateriasAlumno> materias)
        {
            ResponseBase<List<MateriasAlumno>> response = new();
            MateriasAlumno lista = new();
            response.Result = new List<MateriasAlumno>();
            foreach (MateriasAlumno materiasAlumno in materias)
            {
                if(materias.Any(x => x.Materia.HorarioInicio == materiasAlumno.Materia.HorarioInicio && x.MateriaId != materiasAlumno.MateriaId && x.NumeroControl == materiasAlumno.NumeroControl))
                {
                    lista = _customSemestreRepository.GetMateriasDuplicadasSeleccionadas(materiasAlumno.MateriaId, materiasAlumno.Alumno.NumeroControl);
                    response.Result.Add(lista);
                }
            }
            if (response.Result.Count > 0)
            {
                response.Message = "Materias Globales obtenidas";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "No hay materias para este usuario";
                response.Type = ResponseType.Error;
            }
            return response;
        }

        public ResponseBase<List<MateriasAlumno>> GetMateriasGlobales(int alumnoId)
        {
            ResponseBase<List<MateriasAlumno>> response = new();
            response.Result = _customSemestreRepository.GetMateriasGlobales(alumnoId);
            if (response.Result.Count > 0)
            {
                response.Message = "Materias Globales Encontradas";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "No hay materias globales aun";
                response.Type = ResponseType.Warning;
            }
            return response;
        }

        public ResponseBase<int> SetMateriaAsGlobal(MateriasAlumnoVM materiasAlumnos)
        {
            ResponseBase<int> response = new();
            MateriasAlumno materiaModel = new MateriasAlumno
            {
                MateriaAlumnoId = materiasAlumnos.MateriaAlumnoId,
                MaestroId = materiasAlumnos.MaestroId,
                MateriaId = materiasAlumnos.MateriaId,
                NumeroControl = materiasAlumnos.NumeroControl,
            };
            materiaModel.Cursada = 4;
            response.Result = _customSemestreRepository.SetMateriaAsGlobal(materiaModel);

            if (response.Result == 1)
            {
                response.Message = "Materias agregadas a la modalida global";
                response.Type = ResponseType.Success;
            }
            else
            {
                response.Message = "Hubo un error al intentar cambiar la modalidad";
                response.Type = ResponseType.Error;
            }
            return response;
        }

    }
}
