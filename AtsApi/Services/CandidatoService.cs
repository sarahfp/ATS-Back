using AtsApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace AtsApi.Services
{
  public class CandidatoService
  {
    private readonly IMongoCollection<Candidato> _candidatos;

    public CandidatoService(IAtsTotvsDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _candidatos = database.GetCollection<Candidato>(settings.CandidatosCollectionName);
    }

    public List<Candidato> Get() =>
        _candidatos.Find(candidato => true).ToList();

    public Candidato Get(string id) =>
        _candidatos.Find<Candidato>(candidato => candidato.Id == id).FirstOrDefault();

    public Candidato Create(Candidato candidato)
    {
      _candidatos.InsertOne(candidato);
      return candidato;
    }

    /*public ObjectId SaveCurriculo(string fileName, File arquivo)
    {
      var gridFsBucket = new GridFSBucket(_candidatos.Database);
      s = System.IO.File.Create(arquivo);
      var task = Task.Run(() => gridFsBucket.UploadFromStreamAsync(fileName, stream));
      return task.Result;
    }*/

    public void Update(string id, Candidato candidatoIn) =>
        _candidatos.ReplaceOne(candidato => candidato.Id == id, candidatoIn);

    public void Remove(Candidato candidatoIn) =>
        _candidatos.DeleteOne(candidato => candidato.Id == candidatoIn.Id);

    public void Remove(string id) =>
        _candidatos.DeleteOne(candidato => candidato.Id == id);
  }
}
