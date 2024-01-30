using SignalRServer.API.Models;

namespace SignalRServer.API.IService
{
    public interface IHubGameDispatcher
    {
        Task ChangeGame(Games game);
    }
}
