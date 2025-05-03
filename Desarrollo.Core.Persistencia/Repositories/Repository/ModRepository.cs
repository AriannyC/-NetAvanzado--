using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Persistencia.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.Repositories.Repository
{
    public class ModRepository : IProcess<ModGene>  
    {
        private readonly Applicationcontex _applicationcontex;
        public ModRepository(Applicationcontex applicationcontex)
        {
            _applicationcontex = applicationcontex;
        }
        public async Task<(bool IsSucce, string Menssa)> AddAsync(ModGene Entry)
        {
            try
            {
                await _applicationcontex.mods.AddAsync(Entry);
                await _applicationcontex.SaveChangesAsync();
                return (true, "Agregado Correctamente");

            }
            catch (Exception)
            {

                return (true, "No se Agrego Correctamente");
                
            }
        }

        public async Task<(bool IsSucce, string Menssa)> DeleteAsync(int id)
        {
            try
            {

                var tr= await _applicationcontex.mods.FindAsync(id);
                
                if (tr != null)
                {

                    _applicationcontex.mods.Remove(tr);
                    await _applicationcontex.SaveChangesAsync();

                }
                return (true, "Eliminado correctamente");

            }
            catch (Exception)
            {

                return (false, " no se Eliminado correctamente");
            }
        }

        public Task<ModGene> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ModGene> GetByAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<(bool IsSucce, string Menssa)> UpdateAsync(ModGene entry)
        {
            try
            {
                _applicationcontex.Entry(entry).State = EntityState.Modified;
                await _applicationcontex.SaveChangesAsync();
                return (true, "Actualizado Correctamente");
            }
            catch (Exception)
            {

                return (false, "No se Actualizo Correctamente");

            }


        }
    }
}
