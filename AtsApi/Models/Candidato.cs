using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AtsApi.Models
{
  public class Candidato
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("nome")]
    public string nome { get; set; }

    public string email { get; set; }

    public string endereco { get; set; }

    public string datnas { get; set; }

    public string telefone { get; set; }

    public string linkedin { get; set; }

    public string descricao { get; set; }

    public string curriculoID { get; set; }

    public string vagaID { get; set; }

  }
}
