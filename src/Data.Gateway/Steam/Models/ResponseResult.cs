namespace Data.Gateway.Steam.Models;

public class ResponseResult
{
    public UserProfileResponse Response { get; set; }
}

public class UserProfileResponse
{
    public IEnumerable<UserProfile> Players { get; set; }
}