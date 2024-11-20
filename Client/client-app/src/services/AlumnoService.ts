import { Alumno, AlumnoVM, Messages } from "@/utilities/ViewModels";
import axios from "axios";

export default {
    // async $LoggedUser(numeroControl: number, password: string) {
    //     return axios.get<Messages.ResponseBase<Alumno>>(`https://sitecglobal.azurewebsites.net/api/Alumno/Login?numeroControl=${numeroControl}&password=${password}`);
    // },
    async $GetAlumnoByAlumnoId(numeroControl: number) {
        return axios.get<Messages.ResponseBase<AlumnoVM>>(`https://localhost:7023/api/alumno/GetAlumnoByNumeroDeControl?numeroControl=${numeroControl}`);
    },
    async $LoggedUser(numeroControl: number, password: string) {
        return axios.get<Messages.ResponseBase<Alumno>>(`https://localhost:7023/api/alumno/Login?numeroControl=${numeroControl}&password=${password}`);
    },
};