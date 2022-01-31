namespace Web.ApiGateway.Configurations.ConfigHttpClient
{
  public class ConfigureHttpClient
  {
    private readonly WebApplicationBuilder builder;

    public ConfigureHttpClient(WebApplicationBuilder builder)
    {
      this.builder = builder;
    }

    public void Setup()
    {
      builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

      builder.Services.AddHttpClient("contact", c =>
      {
        c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("urls:contact"));
      });

      builder.Services.AddHttpClient("report", c =>
      {
        c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("urls:report"));
      });
    }
  }
}
