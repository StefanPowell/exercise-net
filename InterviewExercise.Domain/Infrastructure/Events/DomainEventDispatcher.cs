using MediatR;

namespace InterviewExercise.Domain.Infrastructure.Events;

public class DomainEventDispatcher : IDomainEventDispatcher
{
    private readonly IMediator _mediator;

    public DomainEventDispatcher(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Dispatch<TEvent>(TEvent @event, CancellationToken token) where TEvent : IDomainEvent
    {
        await _mediator.Publish(@event, token);
    }
}
