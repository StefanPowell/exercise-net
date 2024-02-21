using InterviewExercise.Domain.Commands;
using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.Events;
using InterviewExercise.Domain.Infrastructure.Commands;
using InterviewExercise.Domain.Infrastructure.Events;
using InterviewExercise.Domain.Models.Dto;
using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Domain.EventHandlers.Requests;
public class UpdateRequestHandler : ICommandHandler<UpdateRequestCommand, CreateRequestDto>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IDomainEventDispatcher _dispatcher;

    public UpdateRequestHandler(IRequestRepository requestRepository, IDomainEventDispatcher dispatcher)
    {
        _requestRepository = requestRepository;
        _dispatcher = dispatcher;
    }

    public async Task<CreateRequestDto> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
    {
        var response = _requestRepository.GetAll();

        await _dispatcher.Dispatch(new RequestCreated(response), cancellationToken);

        return new CreateRequestDto { Id = response };
    }
}