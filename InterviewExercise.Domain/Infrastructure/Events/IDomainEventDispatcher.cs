namespace InterviewExercise.Domain.Infrastructure.Events;

public interface IDomainEventDispatcher
{
    Task Dispatch<TEvent>(TEvent @event, CancellationToken token)
        where TEvent : IDomainEvent;
}