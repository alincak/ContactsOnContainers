﻿using System.ComponentModel.DataAnnotations;

namespace ContactService.API.Models
{
  public class ContactEditVo : IValidatableObject
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      var results = new List<ValidationResult>();

      if (string.IsNullOrEmpty(Name))
      {
        yield return new ValidationResult("Cannot be empty", new[] { "Name" });
      }
    }

  }
}
