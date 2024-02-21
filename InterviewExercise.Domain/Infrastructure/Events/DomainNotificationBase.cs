using System.Text.Json.Serialization;

namespace InterviewExercise.Domain.Infrastructure.Events;

public class DomainNotificationBase<T> : IDomainEventNotification<T> where T : IDomainEvent
{
    [JsonIgnore] public T DomainEvent { get; }

    public Guid Id { get; }

    public DomainNotificationBase(T domainEvent)
    {
        this.Id = Guid.NewGuid();
        this.DomainEvent = domainEvent;
    }
}