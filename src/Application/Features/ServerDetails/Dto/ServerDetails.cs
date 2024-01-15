namespace BifrostHub.Application.Features.ServerDetails.Dto;

public class ServerDetails
{
    public int MaxNumberOfPlayers { get; }

    public string GameVersion { get; }

    public string SteamAppId { get; }

    public ServerDetails(int maxNumberOfPlayers, string gameVersion, string steamAppId)
    {
        MaxNumberOfPlayers = maxNumberOfPlayers;
        GameVersion = gameVersion;
        SteamAppId = steamAppId;
    }
}