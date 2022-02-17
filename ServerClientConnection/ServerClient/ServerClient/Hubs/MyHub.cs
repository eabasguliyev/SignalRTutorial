using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ServerClient.Hubs
{
    public class MyHub: Hub
    {
        public async Task SendMessageAsync(string message)
        {
            // some logic
            await Clients.All.SendAsync("receiveMessage", message);
        }


        // Connection Events Handler
        public async override Task OnConnectedAsync()
        {
            // You can get information about client from Context property
            // Context.ConnectionId
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
