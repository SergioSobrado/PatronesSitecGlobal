using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.Interfaces
{
    public class SemestreMateriaCollection
    {
        private readonly List<SemestreMatetrias> _semestresMaterias = new List<SemestreMatetrias>();

        public void AddSemestreMateria(SemestreMatetrias semestreMateria)
        {
            _semestresMaterias.Add(semestreMateria);
        }

        public ISemestreMaterias CreateIterator()
        {
            return new SemestreMateriasIterator(_semestresMaterias);
        }
    }
}
