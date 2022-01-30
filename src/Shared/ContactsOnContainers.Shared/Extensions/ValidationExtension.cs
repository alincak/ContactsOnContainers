using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactsOnContainers.Shared.Extensions
{
  public static class ValidationExtension
  {
    public static string GetErrorsMessages(this ModelStateDictionary modelState)
    { 
      return string.Join("; ", modelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
    }
  }
}
