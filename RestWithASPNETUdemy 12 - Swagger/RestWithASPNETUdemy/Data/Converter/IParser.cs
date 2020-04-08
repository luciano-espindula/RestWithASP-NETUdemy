using System.Collections.Generic;

namespace RestWithASPNETUdemy.Data.Converter
{
    public interface IParser<O, D>
    {
        D Parse(O origem);
        List<D> ParseList(List<O> origem);
    }
}
