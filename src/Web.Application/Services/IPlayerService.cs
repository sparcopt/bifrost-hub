namespace Web.Application.Services;

using Models;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetPlayers();
    Task EnrichPlayerWithSteamProfile(Player player);
}