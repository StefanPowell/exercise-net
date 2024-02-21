using InterviewExercise.Domain.Events;
using MediatR;

namespace InterviewExercise.Domain.EventHandlers.Integrations;

public class RequestCreatedNotificationHandler : INotificationHandler<RequestCreated>
{
    public Task Handle(RequestCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}