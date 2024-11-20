using SITEC.GLOBAL.Domain.Models;

namespace SITEC.GLOBAL.BussinessLogic.Interfaces
{
    public interface ISemestreMaterias
    {
        bool HasNext();
        SemestreMatetrias Next();
    }
}
