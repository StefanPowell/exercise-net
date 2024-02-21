using MediatR;

namespace InterviewExercise.Domain.Infrastructure.Events;

public interface IDomainEvent : INotification
{
    Guid CorrelationId { get; }
    DateTime OccurredOn { get; }
}