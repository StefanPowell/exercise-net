using InterviewExercise.Domain.Commands;
using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.Events;
using InterviewExercise.Domain.Infrastructure.Commands;
using InterviewExercise.Domain.Infrastructure.Events;

namespace InterviewExercise.Domain.EventHandlers.Requests;

public class DeleteRequestHandler : ICommandHandler<DeleteRequestCommand, bool>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IDomainEventDispatcher _dispatcher;

    public DeleteRequestHandler(IRequestRepository requestRepository, IDomainEventDispatcher dispatcher)
    {
        _requestRepository = requestRepository;
        _dispatcher = dispatcher;
    }

    public async Task<bool> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
    {
        var response = _requestRepository.Remove(request.Id);

        if (!response)
            return response;

        await _dispatcher.Dispatch(new RequestDeleted(request.Id), cancellationToken);

        return response;
    }
}