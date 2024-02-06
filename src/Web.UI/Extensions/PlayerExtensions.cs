namespace BifrostHub.Web.UI.Extensions;

using Application.Features.Players.Dto;

public static class PlayerExtensions
{
    public static string GetLastOnlineText(this Player player)
    {
        if (player.IsOnline)
        {
            return "Now";
        }
        
        var timeDifference = DateTime.UtcNow - player.LastOnlineDate;

        if (timeDifference.TotalMinutes < 60)
        {
            var minutes = (int)timeDifference.TotalMinutes;
            return $"{minutes} minutes ago";
        }
        
        if (timeDifference.TotalHours < 24)
        {
            var hours = (int)timeDifference.TotalHours;
            return $"{hours} hours ago";
        }

        if (timeDifference.TotalDays < 365)
        {
            var days = (int)timeDifference.TotalDays;
            return $"{days} days ago";
        }

        var years = (int)(timeDifference.TotalDays / 365);
        var yearDays = (int)(timeDifference.TotalDays % 365);
        return $"{years} years and {yearDays} days ago";
    }

    public static string GetOnlineStatusText(this Player player) => player.IsOnline ? "Online" : "Offline";
}