using InterviewExercise.Domain.Infrastructure.Commands;
using MediatR;

namespace InterviewExercise.Domain.Commands;

public class DeleteRequestCommand : CommandBase, ICommand<bool>
{
    public DeleteRequestCommand(Guid id) : base(id)
    { }
}