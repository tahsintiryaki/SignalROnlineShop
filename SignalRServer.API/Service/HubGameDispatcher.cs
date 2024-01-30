using Microsoft.AspNetCore.SignalR;
using SignalRServer.API.Controllers;
using SignalRServer.API.IService;
using SignalRServer.API.Models;

namespace SignalRServer.API.Service
{
    public class HubGameDispatcher : IHubGameDispatcher
    {
        private readonly IHubContext<GamesHub> _hubContext;
        public HubGameDispatcher(IHubContext<GamesHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task ChangeGame(Games game)
        {
            await this._hubContext.Clients.All.SendAsync("ChangeGame", game);
        }
    }
}
