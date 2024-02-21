using System.Text.Json.Serialization;
using InterviewExercise.Domain.Data;
using InterviewExercise.Domain.EventHandlers;
using InterviewExercise.Domain.EventHandlers.Requests;
using InterviewExercise.Domain.Infrastructure.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(typeof(Program).Assembly, typeof(CreateRequestHandler).Assembly);
});

builder.Services.AddTransient<IRequestRepository, RequestRepository>();
builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();