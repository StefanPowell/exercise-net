using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.Infrastructure.Queries;
using InterviewExercise.Domain.Models.Dto;
using InterviewExercise.Domain.Queries;

namespace InterviewExercise.Domain.EventHandlers.Requests;

public class ReadRequestQueryHandler : IQueryHandler<ReadRequestQuery, ReadRequestDto>
{
    private readonly IRequestRepository _requestRepository;

    public ReadRequestQueryHandler(IRequestRepository requestRepository)
    {
        _requestRepository = requestRepository;
    }
    
    public async Task<ReadRequestDto> Handle(ReadRequestQuery query, CancellationToken cancellationToken)
    {
        var request = _requestRepository.Get(query.Id);
        
        if (request is null) 
            return null;
        
        var result = new ReadRequestDto()
        {
            CustomerId = request.CustomerId,
            RequestType = request.RequestType,
            Notes = request.Notes
        };
        
        return result;
    }
}