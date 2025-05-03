using Desarrollo.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.Repositories.Common
{
    public interface IProcess<T> where T : class
    {
        Task<(bool IsSucce, string Message)> AddAsync(T Entry);
        Task<(bool IsSucce, string Message)> UpdateAsync(T Entry);
        Task<(bool IsSucce, string Message)> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<T> GetByAsync(int id);




    }
}
