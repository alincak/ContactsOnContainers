using ContactService.API.Configurations;
using ContactService.API.Configurations.Extensions;
using ContactService.API.Configurations.Settings;
using ContactService.API.Infrastructure.Repository;
using ContactsOnContainers.Shared.Middlewares.Errors;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
  return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddTransient<IContactRepository, ContactRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.ConfigureRabbitMQ();

var app = builder.Build();

app.ConfigureEventBusForSubscription();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

await app.CreateDBDummyData();

app.Run();
