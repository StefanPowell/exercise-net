using InterviewExercise.Domain.Infrastructure.Events;

namespace InterviewExercise.Domain.Events;

public class RequestDeleted : DomainEventBase
{
    public Guid RequestId { get; }

    public RequestDeleted(Guid id)
    {
        RequestId = id;
    }
}