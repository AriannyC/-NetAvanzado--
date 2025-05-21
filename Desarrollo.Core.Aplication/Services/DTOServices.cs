using Azure;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Repositories.Common;
using Desarrollo.Core.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using Desarrollo.Core.Aplication.Services.Factory;

namespace Desarrollo.Core.Aplication.Services
{
    public class DTOServices
    {

        private readonly IProcess<ModGene> _process;
        private readonly Func<ModGene, int> obtcan = task => (task.DueDate - DateTime.Now).Days;


        public DTOServices(IProcess<ModGene> process) {

            _process = process;
        }
        delegate bool Validate(ModGene gene);




        public async Task<DTOMG<ModGene>> Getall()
        {
            var response = new DTOMG<ModGene>();
            try
            {
                response.DataList = await _process.GetAllAsync();
                response.Successful = true;



            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }



        public async Task<DTOMG<ModGene>> Getby(int id)
        {
            var response = new DTOMG<ModGene>();
            try
            {
                var rss = await _process.GetByAsync(id);
                if (rss != null)
                { response.SingleData = rss;
                    response.Successful = true;
                }
                else
                {
                    response.Successful = false;
                    response.Message = "No se encontro";
                }


            }
            catch (Exception e)
            {
                response.Errors.Add(e.Message);
            }
            return response;
        }
       
        public async Task<DTOMG<string>> Add(ModGene mv)
        {
            Validate vali = gene => !string.IsNullOrWhiteSpace(gene.Description) && gene.DueDate.Date > DateTime.Now.Date;

            var ad = new DTOMG<string>();
            

            try
            {


                if (!vali(mv))
                {
                    ad.Message = "Tiene que ser una fecha futura y la descripcion no puede estar vacia";
                    ad.Successful = true;
                    return ad;

                }

                Action<ModGene> notifyCreation = task =>
            Console.WriteLine($"Tarea creada: {task.Description}, vencimiento: {task.DueDate}");
                
                var res = await _process.AddAsync(mv);
                ad.Successful = res.IsSucce;
                ad.Message = res.Message;
                if (res.IsSucce)
                {

                    notifyCreation(mv); 
                }





            }
            catch (Exception e)
            {
               

                ad.Errors.Add(e.Message);
            }

            return ad;
        
        }
        public async Task<DTOMG<string>> update(ModGene mv)
        {

            var ad = new DTOMG<string>();

            try
            {
                var res = await _process.UpdateAsync(mv);
                ad.Message = res.Message;
                ad.Successful = res.IsSucce;

            }
            catch (Exception e)
            {

                ad.Errors.Add(e.Message);
            }

            return ad;

        }

        public async Task<DTOMG<string>> Delete(int id)
        {

            var ad = new DTOMG<string>();

            try
            {
                var res = await _process.DeleteAsync(id);
                ad.Message = res.Message;
                ad.Successful = res.IsSucce;

            }
            catch (Exception e)
            {

                ad.Errors.Add(e.Message);
            }

            return ad;

        }



        public async Task<DTOMG<string>> AddFactory(string description)

        {
            var af = new DTOMG<string>();
            var afp = ModFactory.CreateHighPriorityTask(description);



            try
            {
                var refw= await _process.AddAsync(afp);
               af.Message=refw.Message;
                af.Successful = refw.IsSucce;

            }
            catch (Exception e) 
            {

                af.Errors.Add(e.Message);
            }

            return af;

        }


}
}
