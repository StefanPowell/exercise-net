using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Api.Models;

public class UpdateRequest
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; }
    public RequestTypes RequestType { get; }
    public string Note { get; }
}