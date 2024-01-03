namespace BifrostHub.Application.Features.Files;

public class FileService : IFileService
{
    private const string RootFolder = "wwwroot";
    private const string DefaultImageExtension = ".jpg";
    private readonly IHttpClientFactory factory;

    public const string SteamAvatarFolder = "steamAvatars";
    
    public FileService(IHttpClientFactory factory)
    {
        this.factory = factory;
    }

    public async Task<string> DownloadRemoteImage(string remoteSourceUri, string savedFileName, string destinationFolder)
    {
        var imageByteArray = await factory.CreateClient().GetByteArrayAsync(remoteSourceUri);
        var downloadPath = $"{RootFolder}/{destinationFolder}/{savedFileName}{DefaultImageExtension}";
        await File.WriteAllBytesAsync(downloadPath, imageByteArray);

        var imagePath = $"{destinationFolder}/{savedFileName}{DefaultImageExtension}";
        return imagePath;
    }
}