using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerClient.Hubs
{
    public class MyHub: Hub
    {
        static List<string> ConnectedClients;

        static MyHub()
        {
            ConnectedClients = new List<string>();
        }
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
            ConnectedClients.Add(Context.ConnectionId);
            await Clients.All.SendAsync("connectedClients", ConnectedClients);
            await Clients.All.SendAsync("userJoined", Context.ConnectionId);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedClients.Remove(Context.ConnectionId);
            await Clients.All.SendAsync("connectedClients", ConnectedClients);
            await Clients.All.SendAsync("userLeft", Context.ConnectionId);
        }
    }
}
