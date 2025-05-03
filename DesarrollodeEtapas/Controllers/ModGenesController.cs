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

namespace DesarrollodeEtapas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModGenesController : ControllerBase
    {
        private readonly DTOServices _context;

        public ModGenesController(DTOServices context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<DTOMG<ModGene>>> Getmods()
        
          =>  await _context.Getall();
        

        [HttpGet("{id}")]
        public async Task<ActionResult<DTOMG<ModGene>>> GetModGene(int id)
        
          =>     await _context.Getby(id);

           

       
        [HttpPut("{id}")]
        public async Task<ActionResult<DTOMG<string>>> PutModGene(ModGene modGene)
        => await _context.update(modGene);

        [HttpPost]
        public async Task<ActionResult<DTOMG<string>>> PostModGene(ModGene modGene)
       => 
            
            
            await _context.Add(modGene);

        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOMG<string>>> DeleteModGene(int id)
        => await _context.Delete(id);
       
    }
}
