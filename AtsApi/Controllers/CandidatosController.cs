using AtsApi.Models;
using AtsApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;

namespace AtsApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CandidatosController : ControllerBase
  {
    private readonly CandidatoService _candidatoService;

    public CandidatosController(CandidatoService candidatoService)
    {
      _candidatoService = candidatoService;
    }

    [HttpGet]
    public ActionResult<List<Candidato>> Get() =>
        _candidatoService.Get();


    [HttpGet("{id:length(24)}", Name = "GetCandidato")]
    public ActionResult<Candidato> Get(string id)
    {
      var candidato = _candidatoService.Get(id);

      if (candidato == null)
      {
        return NotFound();
      }

      return candidato;
    }

    [HttpPost]
    public ActionResult<Candidato> Create(Candidato candidato)
    {
      _candidatoService.Create(candidato);

      //_candidatoService.SaveCurriculo(candidato.nomecurriculo, candidato.stream);

      return CreatedAtRoute("GetCandidato", new { id = candidato.Id.ToString() }, candidato);
    }


    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, Candidato candidatoIn)
    {
      var candidato = _candidatoService.Get(id);

      if (candidato == null)
      {
        return NotFound();
      }

      _candidatoService.Update(id, candidatoIn);

      return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var candidato = _candidatoService.Get(id);

      if (candidato == null)
      {
      }

      _candidatoService.Remove(candidato.Id);

      return NoContent();
    }
  }
}
