using InterviewExercise.Domain.Commands;
using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.Events;
using InterviewExercise.Domain.Infrastructure.Commands;
using InterviewExercise.Domain.Infrastructure.Events;
using InterviewExercise.Domain.Models.Dto;
using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Domain.EventHandlers.Requests;

public class CreateRequestHandler : ICommandHandler<CreateRequestCommand, CreateRequestDto>
{
    private readonly IRequestRepository _requestRepository;
    private readonly IDomainEventDispatcher _dispatcher;

    public CreateRequestHandler(IRequestRepository requestRepository, IDomainEventDispatcher dispatcher)
    {
        _requestRepository = requestRepository;
        _dispatcher = dispatcher;
    }
    
    public async Task<CreateRequestDto> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var customerRequest = Request.RequestCreated(request.CustomerId, request.RequestType, request.Note);
        var response = _requestRepository.Add(customerRequest);

        await _dispatcher.Dispatch(new RequestCreated(response), cancellationToken);
        
        return new CreateRequestDto {Id = response};
    }
}