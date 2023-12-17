namespace Web.Application.Services;

using OdinEye.Models.Api;

public interface IServerDetailsService
{
    Task<ServerDetails> GetServerDetails();
}