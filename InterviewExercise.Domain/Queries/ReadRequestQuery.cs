using InterviewExercise.Domain.Infrastructure.Queries;
using InterviewExercise.Domain.Models.Dto;

namespace InterviewExercise.Domain.Queries;

public class ReadRequestQuery : IQuery<ReadRequestDto>
{
    public Guid Id { get; }
    public ReadRequestQuery(Guid requestId)
    {
        Id = requestId;
    }
}