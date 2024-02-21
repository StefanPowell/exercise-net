using InterviewExercise.Domain.Infrastructure.Events;

namespace InterviewExercise.Domain.Events;

public class RequestCreated : DomainEventBase
{
    public Guid RequestId { get; }
    public RequestCreated(Guid id)
    {
        RequestId = id;
    }
}