using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace ShopServer.API.Hubs
{
    public class Messages:Hub
    {
         public Task AddItemToCar(string meessge)
        {
            return Clients.All.SendAsync("addshoppingcar",meessge);
        } 
    }
}
