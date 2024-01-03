namespace BifrostHub.Application.Features.Players.Dto;

public class SteamUserProfile
{
    public string SteamId { get; }
    
    public string ProfileUrl { get; }
    
    public string Username { get; }
    
    public string Avatar { get; }
    
    public string LocalAvatarImagePath { get; set; }

    public SteamUserProfile(string steamId, string profileUrl, string username, string avatar)
    {
        SteamId = steamId;
        ProfileUrl = profileUrl;
        Username = username;
        Avatar = avatar;
    }
}