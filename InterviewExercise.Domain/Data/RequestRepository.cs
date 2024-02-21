using InterviewExercise.Domain.Models.Request;
using Microsoft.Extensions.Caching.Memory;

namespace InterviewExercise.Domain.Data;

public class RequestRepository : IRequestRepository
{
    private readonly IMemoryCache _memoryCache;

    private static readonly TimeSpan TIMESPAN = TimeSpan.FromHours(5);

    public RequestRepository(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }
    public Guid Add(Request request)
    {
        _memoryCache.Set($"request-{request.Id}", request, TIMESPAN);
        return request.Id;
    }

    public Request? Get(Guid id)
    {
        var request = _memoryCache.Get<Request>($"request-{id}");
        return request ?? null;
    }

    public bool Update(Request updateRequest)
    {
        _memoryCache.Set($"request-{updateRequest.Id}", updateRequest, TimeSpan.FromHours(2));
        return true;
    }

    public bool Remove(Guid id)
    {
        _memoryCache.Remove($"request-{id}");
        return true;
    }

    public List<Request> GetAll()
    {
        //assume it works
        return new List<Request>();
    }
}