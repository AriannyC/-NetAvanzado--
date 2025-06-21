using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desarrollo.Core.Persistencia.Hubs
{
    public class NotificationHub : Hub
    {


        public async Task MJS(string msj)
            =>await Clients.All.SendAsync("ReceiveNotification", msj);
    }
}
