using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.Interfaces
{
    public class SemestreMateriasIterator : ISemestreMaterias
    {
        private readonly List<SemestreMatetrias> _semestreMaterias;
        private int _index = 0;

        public SemestreMateriasIterator(List<SemestreMatetrias> semestreMatetrias)
        {
            _semestreMaterias = semestreMatetrias;
        }

        public bool HasNext()
        {
            return _index < _semestreMaterias.Count;
        }

        public SemestreMatetrias Next()
        {
            if(!HasNext())
            {
                throw new InvalidCastException("No hay Mas semestres.");
            }
            return _semestreMaterias[_index++];
        }
    }
}
