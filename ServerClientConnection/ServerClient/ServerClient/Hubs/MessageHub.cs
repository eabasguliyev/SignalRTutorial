using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerClient.Hubs
{
    public class MessageHub:Hub
    {
        //public async Task SendMessageAsync(string message)
        //public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        public async Task SendMessageAsync(string message, string groupName)
        //public async Task SendMessageAsync(string message, string groupName, IEnumerable<string> connectionIds)
        //public async Task SendMessageAsync(string message, IEnumerable<string> groupNames)
        {
            #region Caller
            // Only caller gets message
            //await Clients.Caller.SendAsync("receiveMessage", message);
            #endregion

            #region All
            // All clients gets message
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region Others
            // All clients gets message except Caller
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region Hub Clients Methods

            #region AllExcept
            // All clients except the provided clients receive messages
            //await Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Client
            // Send message to target Client
            //await Clients.Client(connectionIds.FirstOrDefault()).SendAsync("receiveMessage", message);
            #endregion

            #region Clients
            // Send message to provided clients
            //await Clients.Clients(connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Group
            // Send message to target group
            // First you create a group, then clients subscribe to group
            //await Clients.Group(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region GroupExcept
            // Send message to target group except provided Clients
            //await Clients.GroupExcept(groupName, connectionIds).SendAsync("receiveMessage", message);
            #endregion

            #region Groups
            // Send message to target groups
            //await Clients.Groups(groupNames).SendAsync("receiveMessage", message);
            #endregion

            #region OthersInGroup
            // Send message to target group except Caller
            //await Clients.OthersInGroup(groupName).SendAsync("receiveMessage", message);
            #endregion

            #region User

            #endregion

            #region Users
            #endregion

            #endregion
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("receiveConnectionId", Context.ConnectionId);
        }

        public async Task AddGroup(string connectionId, string groupName)
        {
            await Groups.AddToGroupAsync(connectionId, groupName);
        }
    }
}
