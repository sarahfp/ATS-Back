using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtsApi.Models
{
  public class AtsTotvsDatabaseSettings : IAtsTotvsDatabaseSettings
  {
    public string VagasCollectionName { get; set; }
    public string CandidatosCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
  }

  public interface IAtsTotvsDatabaseSettings
  {
    string VagasCollectionName { get; set; }
    public string CandidatosCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
  }
}