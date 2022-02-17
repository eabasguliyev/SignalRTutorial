using Microsoft.AspNetCore.SignalR;
using ServerClient.Hubs;
using System.Threading.Tasks;

namespace ServerClient.Business
{
    public class MyBusiness
    {
        private IHubContext<MyHub> _hubContext;

        public MyBusiness(IHubContext<MyHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendMessageAsync(string message)
        {
            // some logic
            await _hubContext.Clients.All.SendAsync("receiveMessage", message);
        }
    }
}
