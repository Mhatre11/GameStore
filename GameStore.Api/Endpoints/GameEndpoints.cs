using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.Endpoints;

public static class GetGameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/games").WithParameterValidation();

        group.MapGet("/", (IGamesRepository repository) => repository.GetAll().Select(game => game.AsDto()));
        group.MapGet("/{Id}", (IGamesRepository repository, int Id) =>
        {
            Game? game = repository.Get(Id);
            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();

        }).WithName(GetGameEndpointName);

        // creating game post
        group.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
        {
            Game game = new()
            {
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageURI = gameDto.ImageURI
            };

            repository.Create(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
        });

        group.MapPut("/{Id}", (IGamesRepository repository, int Id, UpdateGameDto updatedGameDto) =>

        {
            Game? existingGame = repository.Get(Id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ImageURI = updatedGameDto.ImageURI;

            repository.Update(existingGame);

            return Results.NoContent();

        });

        // Delete
        group.MapDelete("/{Id}", (IGamesRepository repository, int Id) =>
        {
            Game? game = repository.Get(Id);
            if (game is not null)
            {
                repository.Delete(Id);
            }
            return Results.NoContent();
        });

        return group;
    }

}