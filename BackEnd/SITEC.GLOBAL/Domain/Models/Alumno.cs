namespace SITEC.GLOBAL.Domain.Models
{
    public class Alumno
    {
        public int NumeroControl { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int SemestreId { get; set; }
        public virtual Semestre? Semestre { get; set; }
        public string Carrera { get; set; }
        public int CreditosTotales { get; set; }
        public int CreditosUsados { get; set; } 
        public int TokensTotales { get; set; }
        public int TokensUsados { get; set; }

        public bool IsAdmin { get; set; }
    }
}
