namespace Web.ApiGateway.Extensions
{
  public static class HttpClientExtension
  {
    public async static Task<TResult> PostGetResponseAsync<TResult, TValue>(this HttpClient Client, TValue Value, string Url = "")
    {
      var httpRes = await Client.PostAsJsonAsync(Url, Value);

      return httpRes.IsSuccessStatusCode ? await httpRes.Content.ReadFromJsonAsync<TResult>() : default;
    }

    public async static Task PostAsync<TValue>(this HttpClient Client, TValue Value, string Url = "")
    {
      await Client.PostAsJsonAsync(Url, Value);
    }


    public async static Task<T> GetResponseAsync<T>(this HttpClient Client, string Url = "")
    {
      return await Client.GetFromJsonAsync<T>(Url);
    }

    public async static Task<T> DeleteResponseAsync<T>(this HttpClient Client, string Url = "")
    {
      var httpRes = await Client.DeleteAsync(Url);

      return httpRes.IsSuccessStatusCode ? await httpRes.Content.ReadFromJsonAsync<T>() : default;
    }

  }
}
