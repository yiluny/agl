using System.Collections.Generic;
using System.Threading.Tasks;

namespace agl.Core.Interfaces
{
    public interface ISearch<T>
    {
        Task<string> GetStringFormatFromDataSourceAsync();

        List<T> Transform(string dataSource);

        List<string> GetSearchStringResultsByGender(List<T> data, string gender);
    }
}