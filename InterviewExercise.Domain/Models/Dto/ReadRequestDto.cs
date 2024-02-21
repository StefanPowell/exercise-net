using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Domain.Models.Dto;

public class ReadRequestDto
{
    public Guid CustomerId { get; set; }
    public RequestTypes RequestType { get; set; }
    public string Notes { get; set; }
}