namespace BifrostHub.Infrastructure.Configuration;

using System.ComponentModel.DataAnnotations;

public class OdinEyeOptions
{
    public const string ConfigSectionPath = "OdinEye";
    
    [Required] 
    public string ApiUrl { get; set; }
    
    [Required] 
    public string WebSocketPath { get; set; }
    
    [Required] 
    public double WebSocketReconnectTimeout { get; set; }
    
    [Required] 
    public double WebSocketErrorReconnectTimeout { get; set; }
}