using Desarrollo.Core.Persistencia.Hubs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace DesarrollodeEtapas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationTController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;


        public NotificationTController(IHubContext<NotificationHub> hubContext) { 
            
            
            
            _hubContext = hubContext; 
        }


        [HttpPost("SignalR")]

        public async Task<IActionResult> Sing(string msj)
        {


            await _hubContext.Clients.All.SendAsync("ReceiveNotification", msj);
            return Ok("Enviada");
        }
    
         
    
    
    }

    
}
