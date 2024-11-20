using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.ViewModels
{
    public class AlumnoVM
    {
        public int NumeroControl { get; set; }
        public int SemestreId { get; set; }
        public string Name { get; set; }
        public string Carrera { get; set; }
        public virtual Semestre? Semestre { get; set; }
    }
}
