using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace QuotesApi.Models
{
  public class Quote
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("content")]
    public string Content { get; set; }

    [BsonElement("author")]
    public string Author { get; set; }
  }
}