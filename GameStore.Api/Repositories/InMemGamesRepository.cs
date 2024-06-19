using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;
public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games = new() {
          new Game(){
        Id = 1,
        Name = "Street Fighter II",
        Genre = "Fighting",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991,2 ,1),
        ImageURI= "http://placehold.co/150"
    },
    new Game(){
        Id = 2,
        Name = "Final Fantasy XIV",
        Genre = "RolePlaying",
        Price = 59.99M,
        ReleaseDate = new DateTime(2010,9,30),
        ImageURI = "http://placehold.co/150"
    },
    new Game(){
        Id = 3,
        Name = "FIFA 23",
        Genre = "Sports",
        Price = 69.99M,
        ReleaseDate = new DateTime(2022,9,27),
        ImageURI = "http://placehold.co/150"
    },
    };

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int Id)
    {
        return games.Find(game => game.Id == Id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int Id)
    {
        var index = games.FindIndex(game => game.Id == Id);
        games.RemoveAt(index);

    }

}