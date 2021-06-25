using AtsApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AtsApi.Services
{
  public class VagaService
  {
    private readonly IMongoCollection<Vaga> _vagas;

    public VagaService(IAtsTotvsDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _vagas = database.GetCollection<Vaga>(settings.VagasCollectionName);
    }

    public List<Vaga> Get() =>
        _vagas.Find(vaga => true).ToList();

    public Vaga Get(string id) =>
        _vagas.Find<Vaga>(vaga => vaga.Id == id).FirstOrDefault();

    public Vaga Create(Vaga vaga)
    {
      _vagas.InsertOne(vaga);
      return vaga;
    }

    public void Update(string id, Vaga vagaIn) =>
        _vagas.ReplaceOne(vaga => vaga.Id == id, vagaIn);

    public void Remove(Vaga vagaIn) =>
        _vagas.DeleteOne(vaga => vaga.Id == vagaIn.Id);

    public void Remove(string id) =>
        _vagas.DeleteOne(vaga => vaga.Id == id);
  }
}
