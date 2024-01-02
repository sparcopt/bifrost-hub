namespace Web.Application.Models;

public class SteamUserProfile
{
    public UserProfile Profile { get; }
    public string AvatarImagePath { get; }

    public SteamUserProfile(UserProfile profile, string avatarImagePath)
    {
        Profile = profile;
        AvatarImagePath = avatarImagePath;
    }
}