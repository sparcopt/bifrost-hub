namespace Data.Gateway.Steam.Models;

using System.Text.Json.Serialization;

public class UserProfile
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; set; }
    
    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; set; }
    
    [JsonPropertyName("personaname")]
    public string Username { get; set; }
    
    [JsonPropertyName("avatarfull")]
    public string Avatar { get; set; }
}