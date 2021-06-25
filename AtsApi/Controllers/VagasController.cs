using AtsApi.Models;
using AtsApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AtsApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VagasController : ControllerBase
  {
    private readonly VagaService _vagaService;

    public VagasController(VagaService vagaService)
    {
      _vagaService = vagaService;
    }

    [HttpGet]
    public ActionResult<List<Vaga>> Get() =>
        _vagaService.Get();

    [HttpGet("{id:length(24)}", Name = "GetVaga")]
    public ActionResult<Vaga> Get(string id)
    {
      var vaga = _vagaService.Get(id);

      if (vaga == null)
      {
        return NotFound();
      }

      return vaga;
    }

    [HttpPost]
    public ActionResult<Vaga> Create(Vaga vaga)
    {
      _vagaService.Create(vaga);

      return CreatedAtRoute("GetVaga", new { id = vaga.Id.ToString() }, vaga);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Vaga vagaIn)
    {
      var vaga = _vagaService.Get(id);

      if (vaga == null)
      {
        return NotFound();
      }

      _vagaService.Update(id, vagaIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var vaga = _vagaService.Get(id);

      if (vaga == null)
      {
      }

      _vagaService.Remove(vaga.Id);

      return NoContent();
    }
  }
}
