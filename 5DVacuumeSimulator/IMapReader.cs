using System.Collections.Generic;

namespace VacuumeSimulator
{
    public interface IMapReader
    {
        List<List<ICell>> Read();
    }
}