using GameStore.Models;
using GameStore.ViewModel;

namespace GameStore.Services
{
    public interface IGamesServices
    {
        IEnumerable<Game> GetAll();
        Task Create( CreateGameFromViewModel model);
    }
}
