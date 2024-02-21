using MediatR;

namespace InterviewExercise.Domain.Infrastructure.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{

}