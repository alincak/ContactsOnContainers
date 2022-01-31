using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Web.ApiGateway.Configurations.ConfigHttpClient;
using Web.ApiGateway.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host
  .ConfigureAppConfiguration((hostingContext, config) =>
{
  config.AddJsonFile("Configurations/ocelot.json");
})
 .UseDefaultServiceProvider((context, options) =>
{
  options.ValidateOnBuild = false;
  options.ValidateScopes = false;
});

builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IReportService, ReportService>();

builder.Services.AddOcelot().AddConsul();

builder.Services.AddCors(options =>
{
  options.AddPolicy("CorsPolicy",
      builder => builder.SetIsOriginAllowed((host) => true)
      .AllowAnyMethod()
      .AllowAnyHeader()
      .AllowCredentials());
});

new ConfigureHttpClient(builder).Setup();

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

app.UseCors("CorsPolicy");

await app.UseOcelot();

app.Run();
