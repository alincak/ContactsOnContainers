﻿using System.ComponentModel.DataAnnotations;

namespace ContactService.API.Models
{
  public class ContactInfoVo : IValidatableObject
  {
    public string Id { get; set; }
    public string ContactId { get; set; }
    public int InfoType { get; set; }
    public string Value { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      var results = new List<ValidationResult>();

      if (string.IsNullOrEmpty(Value))
      {
        yield return new ValidationResult("Cannot be empty", new[] { "Value" });
      }

      if (string.IsNullOrEmpty(ContactId))
      {
        yield return new ValidationResult("Cannot be empty", new[] { "ContactId" });
      }
    }

  }
}
