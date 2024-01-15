namespace BifrostHub.Application.Features.Files;

public interface IFileService
{
    Task<string> DownloadRemoteImage(string remoteSourceUri, string savedFileName, string destinationFolder);
}