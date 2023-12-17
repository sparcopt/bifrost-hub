namespace Data.Gateway.Configuration;

using System.ComponentModel.DataAnnotations;

public class SteamOptions
{
    public const string ConfigSectionPath = "Steam";
    
    [Required]
    public string ApiUrl { get; set; }
    
    [Required]
    public string ApiKey { get; set; }
}