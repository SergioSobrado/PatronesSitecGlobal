using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITEC.GLOBAL.Domain.Models
{
    public class Materia
    {
        public int MateriaId { get; set; }
        public string Name { get; set; }
        public TimeOnly HorarioInicio { get; set; }
        public TimeOnly HoraFinal { get; set; }
        public string Serie { get; set; }
        public bool IsGlobal {  get; set; }
        public int Creditos { get; set; }
    }
}
