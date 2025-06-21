using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Aplication.Services;
using Desarrollo.Core.Domain.DTO;
using Desarrollo.Core.Persistencia.Repositories.Repository;
using Desarrollo.Core.Persistencia.Repositories.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Desarrollo.Core.Persistencia.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DesarrollodeEtapas.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[AllowAnonymous]

    [ApiController]
    public class ModGenesController : ControllerBase
    {
        private readonly DTOServices _context;
        private readonly Applicationcontex _application;
        private readonly IHubContext<NotificationHub> _hubContext;



        public ModGenesController(DTOServices context, Applicationcontex application, IHubContext<NotificationHub>hubContext)
        {
            _context = context;
            _hubContext = hubContext;
            _application = application;
        }

      



        [HttpGet]
        public async Task<ActionResult<DTOMG<ModGene>>> Getmods()
        
          =>  await _context.Getall();

        [HttpPost("porcen")]
        public async Task<ActionResult<double>> getporc(List<ModGene> gn)

        {
            double res = DTOServices.CalculateCompletionRate(gn);
            return Ok(res);
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DTOMG<ModGene>>> GetModGene(int id)
        
          =>     await _context.Getby(id);

        [HttpGet("Pendientes")]

        public async Task<ActionResult<DTOMG<List<ModGene>>>> getpendien()
        {

            return Ok(new
            {
                can = await _application.mods.Where(tas => tas.Status == "Pendiente").ToListAsync()
            });
        }
       

        [HttpPost("calculate")]
        public async Task<ActionResult<DTOMG<ModGene>>> Calcu(ModGene task1)
       => await _context.Calculate(task1);




        [HttpPut("{id}")]
        public async Task<ActionResult<DTOMG<string>>> PutModGene(ModGene modGene)
        => 
            
            await _context.update(modGene);


        [HttpPost]
        public async Task<ActionResult<DTOMG<string>>> PostModGene(ModGene modGene)
        {
            var result = await _context.Add(modGene);

            if (result.Successful)
            {
                await _hubContext.Clients.All.SendAsync("TareaUrgente", new
                {
                    descripcion = modGene.Description,
                    vencimiento = modGene.DueDate,
                    mensaje = "¡Nueva tarea urgente registrada!"
                });

                return Ok(result);
            }

            return BadRequest(result);
        }





        [HttpPost("Factory")]
        public async Task<ActionResult<DTOMG<string>>> PostModfac(string description)
       =>
             await _context.AddFactory(description);

        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOMG<string>>> DeleteModGene(int id)
        => await _context.Delete(id);
       
    }
}
