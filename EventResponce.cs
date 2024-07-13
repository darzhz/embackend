using embackend.Models;
public class EventCreatedResponse
{
    public Event Event { get; set; }
    public string Message { get; set; }

    public EventCreatedResponse(Event eventEntity, string message)
    {
        Event = eventEntity;
        Message = message;
    }
}