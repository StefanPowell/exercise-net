using InterviewExercise.Domain.Infrastructure.Events;

namespace InterviewExercise.Domain.Events;

public class RequestUpdated : DomainEventBase
{
    public Guid RequestId { get; }
    public RequestUpdated(Guid id)
    {
        RequestId = id;
    }
}