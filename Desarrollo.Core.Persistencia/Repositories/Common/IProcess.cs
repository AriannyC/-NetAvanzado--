using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.Repositories.Common
{
    public interface IProcess<T> where T : class
    {
        Task<(bool IsSucce, string Menssa)> AddAsync(T Entry);
        Task<(bool IsSucce, string Menssa)> UpdateAsync(T Entry);
        Task<(bool IsSucce, string Menssa)> DeleteAsync(int id);
        Task<T> GetAllAsync();
        Task<T> GetByAsync(int id);




    }
}
