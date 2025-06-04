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

namespace DesarrollodeEtapas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModGenesController : ControllerBase
    {
        private readonly DTOServices _context;
        private readonly Applicationcontex _application;
       

        public ModGenesController(DTOServices context, Applicationcontex application)
        {
            _context = context;
            _application = application;
        }

      



        [HttpGet]
        public async Task<ActionResult<DTOMG<ModGene>>> Getmods()
        
          =>  await _context.Getall();
        

        [HttpGet("{id}")]
        public async Task<ActionResult<DTOMG<ModGene>>> GetModGene(int id)
        
          =>     await _context.Getby(id);

        [HttpGet("Pendientes")]

        public async Task<ActionResult<DTOMG<List<ModGene>>>> getpendien()
        {

            return Ok(new { can = await _application.mods.Where(tas => tas.Status == "Pendiente").ToListAsync()
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
       => 
            
            
            await _context.Add(modGene);


        [HttpPost("Factory")]
        public async Task<ActionResult<DTOMG<string>>> PostModfac(string description)
       =>
             await _context.AddFactory(description);

        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOMG<string>>> DeleteModGene(int id)
        => await _context.Delete(id);
       
    }
}
