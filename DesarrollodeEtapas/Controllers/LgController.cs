using Desarrollo.Core.Domain.DTO;
using Desarrollo.Core.Domain.Models;
using Desarrollo.Core.Persistencia.Context;
using Desarrollo.Core.Persistencia.TokenJWT;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Text.Json;

namespace DesarrollodeEtapas.Controllers
{
    public class LgController : Controller
    {
        private readonly Applicationcontex _user;
        private readonly TOKEN _utilidad;
        private readonly IConfiguration _configuration;

        public LgController(Applicationcontex user, TOKEN utilidad, IConfiguration configuration)
        {
            _user = user;
            _utilidad = utilidad;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("Registrarte")]
        public async Task<IActionResult> Registrarte(LDTO Us)
        {
            try
            {
                var model = new Ustoken
                {
                    Username = Us.Username,
                    Password = _utilidad.encriptar(Us.Password),
                    
                };


                await _user.ustokens.AddAsync(model);
                await _user.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { isSuccess = model.IdR != 0 });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { isSuccess = false });
            }
        }


        [HttpPost]
        [Route("LOGIN")]
        public async Task<IActionResult> LGN(LDTO OB)
        {

            var encontrados = await _user.ustokens.Where(u => u.Username == OB.Username
            && u.Password == _utilidad.encriptar(OB.Password)).FirstOrDefaultAsync();

            if (encontrados == null)
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = false, token = "" });
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = true, token = _utilidad.GeneratJTW(encontrados) });

            }
        }
    }
}
