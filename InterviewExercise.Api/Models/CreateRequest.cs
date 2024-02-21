using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Api.Models;
public class CreateRequest
{
    public Guid CustomerId { get; set; }
    public RequestTypes RequestType { get; set; }
    public string Note { get; set; }
}