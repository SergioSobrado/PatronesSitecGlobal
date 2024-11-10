import { Messages, MateriasAlumno, MateriasAlumnoVM } from "@/utilities/ViewModels";
import axios from "axios";

export default {
    // async $LoggedUser(numeroControl: number, password: string) {
    //     return axios.get<Messages.ResponseBase<Alumno>>(`https://sitecglobal.azurewebsites.net/api/Alumno/Login?numeroControl=${numeroControl}&password=${password}`);
    // },
    async $GetMateriasBySemestreId(alumnoId: number) {
        return axios.get<Messages.ResponseBase<MateriasAlumno[]>>(`https://localhost:7023/api/Materias/GetMateriasAvailableToStudent?alumnoId=${alumnoId}`);
    },
    async $finishCarga(materiasAlumnos: MateriasAlumnoVM[]) {
        return axios.post<Messages.ResponseBase<number>>(`https://localhost:7023/api/Materias/NewMateriasToStudent`, materiasAlumnos);
    },
    async $GetMateriasCursandoByAlumnoId(alumnoId: number) {
        return axios.get<Messages.ResponseBase<MateriasAlumno[]>>(`https://localhost:7023/api/Materias/GetMateriasCursandoPorAlumno?alumnoId=${alumnoId}`);
    },
    async $GetMateriasDisponiblesParaGlobal(materias: MateriasAlumno[]) {     
        return axios.post<Messages.ResponseBase<MateriasAlumno[]>>("https://localhost:7023/api/Materias/GetMateriasDuplicadasSeleccionadas",materias);
    },
    async $GetMateriasGlobales(alumnoId: number) {
        return axios.get<Messages.ResponseBase<MateriasAlumno[]>>(`https://localhost:7023/api/Materias/GetMateriasGlobales?alumnoId=${alumnoId}`);
    },
    async $SetMateriaAsGlobal(materias: MateriasAlumnoVM){
        return axios.post<Messages.ResponseBase<number>>("https://localhost:7023/api/Materias/SetMateriaAsGlobal", materias)
    }
};