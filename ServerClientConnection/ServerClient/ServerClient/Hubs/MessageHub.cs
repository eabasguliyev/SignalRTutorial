using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ServerClient.Hubs
{
    public class MessageHub:Hub
    {
        public async Task SendMessageAsync(string message)
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
            await Clients.Others.SendAsync("receiveMessage", message);
            #endregion
        }
    }
}
