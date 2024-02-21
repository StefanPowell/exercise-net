namespace InterviewExercise.Domain.Infrastructure.Events;

public class DomainEventBase : IDomainEvent
{
    public DomainEventBase()
    {
        OccurredOn = DateTime.Now;
        CorrelationId = Guid.NewGuid();
    }

    public Guid CorrelationId { get; }
    public DateTime OccurredOn { get; }
}