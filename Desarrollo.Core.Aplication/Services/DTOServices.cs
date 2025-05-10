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

namespace Desarrollo.Core.Aplication.Services
{
    public class DTOServices
    {

        private readonly IProcess<ModGene> _process;

        public DTOServices(IProcess<ModGene> process) {
        
        _process = process;
        }



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
                {     response.SingleData= rss;
                    response.Successful = true;
                }
                else
                {
                    response.Successful= false;
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

            var ad = new DTOMG<string>();
            

            try
            {
                if(mv.DueDate.Date > DateTime.Now.Date)
                {
                    var res = await _process.AddAsync(mv);
                    ad.Message = res.Message;
                    ad.Successful = res.IsSucce;
                }
                else
                {
                    ad.Successful = false;
                    ad.Message = "Tiene que ser una fecha futura";
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



    }
}
