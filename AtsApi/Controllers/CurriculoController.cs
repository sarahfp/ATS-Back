using AtsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AtsApi.Models;

namespace AtsApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CurriculosController : ControllerBase
  {
    private readonly CurriculoService _curriculoService;

    public CurriculosController(CurriculoService curriculoService)
    {
      _curriculoService = curriculoService;
    }

    [HttpPost]
    [Route("/upload")]
    public ActionResult<Curriculo> Upload(IFormFile files)
    {
      var id = _curriculoService.UploadFile(files);
      Curriculo curriculo= new Curriculo();
      curriculo.curriculoID = id.ToString();
      return curriculo;
    }


    [HttpPost]
    [Route("/download")]
    public ActionResult<byte[]> Download(Curriculo curriculo)
    {
      return _curriculoService.DownloadFile(curriculo.curriculoID);
    }
  }
}

