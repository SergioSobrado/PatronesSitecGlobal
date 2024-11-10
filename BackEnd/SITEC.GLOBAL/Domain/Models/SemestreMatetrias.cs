namespace SITEC.GLOBAL.Domain.Models
{
    public class SemestreMatetrias
    {
        public int SemestreMateriasId { get; set; }
        public int SemestreId { get; set; }
        public int MateriaId { get; set; }

        public virtual Semestre? Semestre { get; set; }
        public virtual Materia? Materia { get; set; }
        
    }
}
