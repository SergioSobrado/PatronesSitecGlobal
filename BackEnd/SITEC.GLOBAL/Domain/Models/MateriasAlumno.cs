namespace SITEC.GLOBAL.Domain.Models
{
    public class MateriasAlumno
    {
        public int MateriaAlumnoId { get; set; }
        public int NumeroControl { get; set; }
        public int MateriaId { get; set; }
        public int Cursada {  get; set; }
        public int MaestroId { get; set; }


        public virtual Maestro Maestro { get; set; }
        public virtual Alumno Alumno {  get; set; }
        public virtual Materia Materia { get; set; }
    }
}
