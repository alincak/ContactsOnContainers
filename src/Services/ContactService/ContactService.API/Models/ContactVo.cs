﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ContactService.API.Models
{
  public class ContactVo : IValidatableObject
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public IList<ContactInfoVo> ContactInfos { get; set; } = new List<ContactInfoVo>();

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
