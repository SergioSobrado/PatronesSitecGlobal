import { Alumno, Messages } from "@/utilities/ViewModels";
import axios from "axios";

export default {
    // async $LoggedUser(numeroControl: number, password: string) {
    //     return axios.get<Messages.ResponseBase<Alumno>>(`https://sitecglobal.azurewebsites.net/api/Alumno/Login?numeroControl=${numeroControl}&password=${password}`);
    // },
    async $LoggedUser(numeroControl: number, password: string) {
        return axios.get<Messages.ResponseBase<Alumno>>(`https://localhost:7023/api/alumno/Login?numeroControl=${numeroControl}&password=${password}`);
    },
};