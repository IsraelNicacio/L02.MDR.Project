using Microsoft.AspNetCore.Mvc;

namespace MDR.Cadastro.Api.Controllers;

[ApiController]
[Route("{tenant}/[controller]")]
public class PessoaController : ControllerBase
{
    [HttpGet(Name = "Pessoas")]
    public IActionResult Get()
    {
        return default;
    }
}
