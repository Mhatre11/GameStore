using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    void Create(Game game);
    void Delete(int Id);
    Game? Get(int Id);
    IEnumerable<Game> GetAll();
    void Update(Game updatedGame);
}
