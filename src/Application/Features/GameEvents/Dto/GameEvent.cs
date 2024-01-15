namespace BifrostHub.Application.Features.GameEvents.Dto;

public class GameEvent
{
    public DateTime CreatedDate { get; }
    
    public string Message { get; }
    
    public EventType Type { get; }
    
    public Player Player { get; }
    
    public IDictionary<string, object> Data { get; }

    public GameEvent(DateTime createdDate, string message, EventType type, Player player, IDictionary<string, object> data)
    {
        CreatedDate = createdDate;
        Message = message;
        Type = type;
        Player = player;
        Data = data;
    }
}