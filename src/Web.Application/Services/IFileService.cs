namespace Web.Application.Services;

public interface IFileService
{
    Task<string> DownloadRemoteImage(string remoteSourceUri, string savedFileName, string destinationFolder);
}