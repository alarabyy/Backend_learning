using GameStore.Models;
using GameStore.ViewModel;

namespace GameStore.Services
{
    public interface IGamesServices
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        Task Create( CreateGameFromViewModel model);
        Task<Game?> Update ( EditGameFormViewModel model);
        bool Delete(int id);
    }
}
