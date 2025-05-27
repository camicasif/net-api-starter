using dotnet_api_template.DTOs;
using dotnet_api_template.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_api_template.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _repository;

    public EmpleadoService(IEmpleadoRepository repository)
    {
        _repository = repository; 
    }

    public async Task<IEnumerable<EmpleadoDto>> ObtenerTodosAsync()
    {
        var empleados = await _repository.GetAllAsync();
        return empleados.Select(e => new EmpleadoDto
        {
            NombreCompleto = $"{e.Nombre} {e.Apellido}",
            Sueldo = e.Sueldo
        });
    }

    public async Task<EmpleadoDto> ObtenerPorIdAsync(int id)
    {
        var e = await _repository.GetByIdAsync(id);
        return new EmpleadoDto
        {
            NombreCompleto = $"{e.Nombre} {e.Apellido}",
            Sueldo = e.Sueldo
        };
    }
}
