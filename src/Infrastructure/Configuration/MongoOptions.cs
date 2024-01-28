namespace BifrostHub.Infrastructure.Configuration;

using System.ComponentModel.DataAnnotations;

public class MongoOptions
{
    public const string ConfigSectionPath = "Mongo";
    
    [Required]
    public string ConnectionString { get; set; }
}