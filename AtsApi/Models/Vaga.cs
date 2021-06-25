using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AtsApi.Models
{
  public class Vaga
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("nome")]
    public string nome { get; set; }

    public string descricao { get; set; }

    public string local { get; set; }
  }
}