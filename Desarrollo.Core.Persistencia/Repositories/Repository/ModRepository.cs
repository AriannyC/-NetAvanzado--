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

        delegate bool Validate(ModGene gene);
        private readonly Func<ModGene, int> obtcan = task => (task.DueDate - DateTime.Now).Days;

        public async Task<ModGene> caontobt(ModGene gene)
        {






            return null;
        }


            
        
        public async Task<(bool IsSucce, string Message)> AddAsync(ModGene Entry)
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

        public async Task<(bool IsSucce, string Message)> DeleteAsync(int id)
        {
            try
            {

                var tr= await _applicationcontex.mods.FindAsync(id);
                
                if (tr != null)
                {

                    _applicationcontex.mods.Remove(tr);
                    await _applicationcontex.SaveChangesAsync();
                    return (true, "Eliminado correctamente");


                }
                return (true, "ENCONTRO correctamente");

            }
            catch (Exception)
            {

                return (false, " no se Eliminado correctamente");
            }
        }

        public async Task<IEnumerable<ModGene>> GetAllAsync()

           => await _applicationcontex.mods.ToListAsync();


        public async Task<ModGene> GetByAsync(int id)

            => await _applicationcontex.mods.FirstOrDefaultAsync(x=> x.Id==id);
        
        public async Task<(bool IsSucce, string Message)> UpdateAsync(ModGene entry)
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
