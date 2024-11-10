namespace SITEC.GLOBAL.Domain.Models
{
    public class Request
    {
        public int Id { get; set; }
        public int NumeroControl { get; set; }

        public virtual Alumno Alumno { get; set; }
    }
}
