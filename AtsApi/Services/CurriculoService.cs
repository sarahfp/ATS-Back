using AtsApi.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System.Threading.Tasks;

namespace AtsApi.Services
{
  public class CurriculoService
  {
    private readonly GridFSBucket fs;

    public CurriculoService(IAtsTotvsDatabaseSettings settings)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);
      fs = new GridFSBucket(database);
    }

    public ObjectId UploadFile(IFormFile file)
    {
        var t = Task.Run<ObjectId>(() => {
          return
          fs.UploadFromStreamAsync("curriculo.pdf", file.OpenReadStream());
        });

        Task.WaitAll(t);

        return t.Result;
    }

    public byte[] DownloadFile(string curID)
    {
      ObjectId id = new ObjectId(curID);
      var arquivo = fs.DownloadAsBytes(id);
      return arquivo;
    }

  }


}
