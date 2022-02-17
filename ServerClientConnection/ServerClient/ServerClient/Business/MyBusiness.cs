using Microsoft.AspNetCore.SignalR;
using ServerClient.Hubs;
using ServerClient.Interfaces;
using System.Threading.Tasks;

namespace ServerClient.Business
{
    public class MyBusiness
    {
        private IHubContext<MyHub, IMessageClient> _hubContext;

        public MyBusiness(IHubContext<MyHub, IMessageClient> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            // some logic
            await _hubContext.Clients.All.ReceiveMessage(message);
        }
    }
}
