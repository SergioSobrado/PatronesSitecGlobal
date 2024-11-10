using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEC.GLOBAL.Domain.Models
{ 
    public class Grupo
    {
        public int GrupoId { get; set; }
        public int MaestroId {  get; set; }
        public int MateriaId { get; set; }
        public int AlumnoId { get; set; }

        public virtual Maestro? Maestro { get; set; }
        public virtual Alumno? Alumno { get; set; }
        public virtual Materia? Materias { get; set; }
        

    }
}
