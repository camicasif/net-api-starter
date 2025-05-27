using Microsoft.AspNetCore.Mvc;
using dotnet_api_template.DTOs;
using dotnet_api_template.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpleadoController : ControllerBase
{
    private readonly IEmpleadoService _service;

    public EmpleadoController(IEmpleadoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        return Ok(await _service.ObtenerTodosAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await _service.ObtenerPorIdAsync(id);
        if (empleado == null) return NotFound();
        return Ok(empleado);
    }
}
