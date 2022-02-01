namespace Web.ApiGateway.Infrastructure
{
  public class HttpClientDelegatingHandler : DelegatingHandler
  {
    private readonly IHttpContextAccessor httpContextAccessor;

    public HttpClientDelegatingHandler(IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      return base.SendAsync(request, cancellationToken);
    }

  }
}
