using dotnet_api_template.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Services;

public interface IEmpleadoService
{
    Task<IEnumerable<EmpleadoDto>> ObtenerTodosAsync();
    Task<EmpleadoDto> ObtenerPorIdAsync(int id);

    Task<ResponseDto<EmpleadoDto>> CrearOActualizarEmpleadoAsync(EmpleadoDto dto);

}
