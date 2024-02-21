namespace InterviewExercise.Domain.Models.Request;

public class Request  
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; set; }
    public RequestTypes RequestType { get; set; }
    public string Notes { get; set; }
    private Request(Guid customerId, RequestTypes requestType, string notes)
    {
        Id = Guid.NewGuid();
        CustomerId = customerId;
        RequestType = requestType;
        Notes = notes;
    }   
    public static Request RequestCreated(Guid customerId, RequestTypes requestType, string note)
    {
        return new Request(customerId, requestType, note);
    }
}