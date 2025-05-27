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
    private readonly IEmpleadoService _empleadoService;

    public EmpleadoController(IEmpleadoService empleadoService)
    {
        _empleadoService = empleadoService;
    }



    [HttpPost]
    public async Task<IActionResult> CrearOActualizarEmpleado([FromBody] EmpleadoDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var resultado = await _empleadoService.CrearOActualizarEmpleadoAsync(dto);

        if (!resultado.EsExitoso)
            return BadRequest(resultado.Mensaje);

        return Ok(resultado.Data);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var empleado = await _empleadoService.ObtenerPorIdAsync(id);
        if (empleado == null) return NotFound();
        return Ok(empleado);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> EliminarEmpleado(int id)
    {
        var resultado = await _empleadoService.EliminarEmpleadoAsync(id);

        if (!resultado.EsExitoso)
        {
            return NotFound(resultado.Mensaje);
        }

        return Ok(resultado);
    }
}
