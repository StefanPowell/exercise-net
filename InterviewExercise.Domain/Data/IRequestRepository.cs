using InterviewExercise.Domain.Models.Request;

namespace InterviewExercise.Domain.Data;

public interface IRequestRepository
{
    Guid Add(Request request);
    Request? Get(Guid id);
    bool Update(Request request);
    bool Remove(Guid id);
    List<Request> GetAll(); 
}