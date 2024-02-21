using InterviewExercise.Domain.Infrastructure.Commands;
using InterviewExercise.Domain.Models.Dto;
using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Domain.Commands;

public class CreateRequestCommand : CommandBase<CreateRequestDto>
{
    public Guid CustomerId { get; }
    public RequestTypes RequestType { get; }
    public string Note { get; }

    public CreateRequestCommand(Guid customerId, RequestTypes requestType, string note)
    {
        CustomerId = customerId;
        RequestType = requestType;
        Note = note;
    }
}