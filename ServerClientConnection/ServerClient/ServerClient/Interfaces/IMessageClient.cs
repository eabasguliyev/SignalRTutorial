using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServerClient.Interfaces
{
    public interface IMessageClient
    {
        Task ConnectedClients(List<string> clientList);
        Task UserJoined(string connectionId);
        Task UserLeft(string connectionId);
        Task ReceiveMessage(string message);
    }
}
