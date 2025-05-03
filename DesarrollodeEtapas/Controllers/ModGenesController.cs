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

        // GET: api/ModGenes
        [HttpGet]
        public async Task<ActionResult<DTOMG<ModGene>>> Getmods()
        
          =>  await _context.Getall();
        

        // GET: api/ModGenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOMG<ModGene>>> GetModGene(int id)
        
          =>     await _context.Getby(id);

           

        // PUT: api/ModGenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<DTOMG<string>>> PutModGene(ModGene modGene)
        => await _context.update(modGene);

        // POST: api/ModGenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DTOMG<string>>> PostModGene(ModGene modGene)
       => await _context.Add(modGene);

        // DELETE: api/ModGenes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DTOMG<string>>> DeleteModGene(int id)
        => await _context.Delete(id);
       
    }
}
