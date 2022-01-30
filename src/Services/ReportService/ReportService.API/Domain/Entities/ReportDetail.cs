using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ReportService.API.Domain.Entities
{
  public class ReportDetail
  {
    [BsonRepresentation(BsonType.String)]
    public string Location { get; set; }
    [BsonRepresentation(BsonType.Int32)]
    public int ContactCount { get; set; }
    [BsonRepresentation(BsonType.Int32)]
    public int PhoneNumberCount { get; set; }
  }
}