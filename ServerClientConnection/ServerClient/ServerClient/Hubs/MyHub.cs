using Microsoft.AspNetCore.SignalR;
using ServerClient.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerClient.Hubs
{
    public class MyHub: Hub<IMessageClient>
    {
        static List<string> ConnectedClients;

        static MyHub()
        {
            ConnectedClients = new List<string>();
        }

        public async Task SendMessageAsync(string message)
        {
            // some logic
            //await Clients.All.SendAsync("receiveMessage", message);
            await Clients.All.ReceiveMessage(message);
        }


        // Connection Events Handler
        public async override Task OnConnectedAsync()
        {
            // You can get information about client from Context property
            // Context.ConnectionId
            ConnectedClients.Add(Context.ConnectionId);
            await Clients.All.ConnectedClients(ConnectedClients);
            await Clients.All.UserJoined(Context.ConnectionId);
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedClients.Remove(Context.ConnectionId);
            await Clients.All.ConnectedClients(ConnectedClients);
            await Clients.All.UserLeft(Context.ConnectionId);
        }
    }
}
