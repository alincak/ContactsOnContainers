using ContactService.API.Domain.Entities;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContactService.API.Models
{
  public class ContactInfoVo : IValidatableObject
  {
    public int InfoType { get; set; }
    public string Value { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      var results = new List<ValidationResult>();

      if (string.IsNullOrEmpty(Value))
      {
        yield return new ValidationResult("Cannot be empty", new[] { "Value" });
      }
    }

  }
}
