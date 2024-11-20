export interface MateriasAlumno {
    id: number;
    numeroControl: number;
    materiaId: number;
    cursada: number;
    maestroId: number;
    materias?: MateriaVM | null;
    semestre?: SemestreVM | null;
    maestro?: Maestro | null;
}

export interface MateriasAlumnoVM {
    materiaAlumnoid: number;
    maestroId: number;
    numeroControl: number;
    materiaId: number;
    cursada: number;
}

export interface SemestreVM{
    semestreId: number;
    name: string;
}

export interface MateriaVM{
    id: number;
    name: string;
    horarioInicio: Date;
    horaFinal: Date;
    serie: string;
    isSelected?: boolean;
    isGlobal: boolean;
    creditos: number;
}

export interface Alumno {
    numeroControl: number;
    name: string;
    password: string;
    email: string;
    semestreId: number;
    semestre: SemestreVM;
    carrera: string;
    creditosTotales: number;
    creditosUsados: number;
    isAdmin: boolean;
}

export interface AlumnoVM {
    numeroControl: number;
    name: string;
    semestreId: number;
    carrera: string;
    semestre: SemestreVM;
}

export interface MateriasAlumno {
    materiaAlumnoId: number;
    numeroControl: number;
    materiaId: number;
    cursada: number;
    alumno: Alumno;
    materia: MateriaVM;
}

export interface Maestro {
    maestroId: number;
    name: string;
}


export namespace Messages {
    export interface ResponseBase<T> {
        type: ResponseType;
        message: string;
        result: T 
    }
}

export enum ResponseType {
    Success = 1,
    Warning,
    Error
}


export interface RequestVM {
    id: number;
    name: string;
    createdOn: string;
    numeroControl: number;
    semestre: number;
    promedio: number;
    reprobadas: number;
}