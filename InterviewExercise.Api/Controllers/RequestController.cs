using InterviewExercise.Api.Models;
using InterviewExercise.Domain.Commands;
using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.Models.Dto;
using InterviewExercise.Domain.Models.Request;
using InterviewExercise.Domain.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Text;

namespace InterviewExercise.Api.Controllers;

/// <summary>
/// 1. Given Create, Get and Delete apis, implement Update. (encourage using available classes in InterviewExercise.Domain as much as possible)
/// 2. Create an API that returns aggregated list of customer ids who created request
/// 3. When a Request is Updated, make a Http Post request to a provided webhook URL with updated data.
///
/// * Make sure each apis return Objects, Status Codes specified in Swagger Documentation.
/// * Feel free to use any packages from nuget
/// * If you're not familiar or unsure with the design pattern, feel free to implement the way you prefer
/// * Feel free to use any IDE/Tools
/// </summary>
[Route("api/requests")]
public class RequestController : Controller
{
    private readonly IMediator _mediator;
    private readonly IRequestRepository _requestRepository;

    public RequestController(IMediator mediator, IRequestRepository requestRepository)
    {
        _mediator = mediator;
        _requestRepository = requestRepository;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateRequest([FromBody]CreateRequest request)
    {
        var createRequest =
            await _mediator.Send(
                new CreateRequestCommand(request.CustomerId, request.RequestType, request.Note));
        
        return Created(String.Empty, createRequest.Id);
    }

    [HttpGet("{id:Guid}")]
    [ProducesResponseType(typeof(ReadRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetRequest(Guid id)
    {
        var request = await _mediator.Send(new ReadRequestQuery(id));
        return Ok(request);
    }


    [HttpGet]
    [ProducesResponseType(typeof(ReadRequestDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public List<Guid> GetAll()
    {
        List<Guid> allcustomerids = new List<Guid>();
        var allrequest =  _requestRepository.GetAll();
        foreach (var request in allrequest)
        {
            allcustomerids.Add(request.CustomerId);
        }
        return allcustomerids;
    }


    [HttpPut("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateRequest(UpdateRequest request)
    {
        await _mediator.Send(new DeleteRequestCommand(request.Id));
        await _mediator.Send(
                new CreateRequestCommand(request.CustomerId, request.RequestType, request.Note));

        HttpContent xcontent = new StringContent(request.ToString(), Encoding.UTF8, "application/json");
        HttpClient httpClient = new HttpClient();
        Task<HttpResponseMessage> httpResponseMessage = httpClient.PostAsync("https://www.google.com", xcontent);
        

        return Accepted();
    }

    [HttpDelete("{id:Guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> RemoveRequest(Guid id)
    {
        var result = await _mediator.Send<bool>(new DeleteRequestCommand(id));
        return Ok();
    }
}