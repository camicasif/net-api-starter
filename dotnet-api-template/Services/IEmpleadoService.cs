using dotnet_api_template.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Services;

public interface IEmpleadoService
{
    Task<IEnumerable<EmpleadoDto>> ObtenerTodosAsync();
    Task<ResponseDto<EmpleadoDto>> ObtenerEmpleadoPorIdAsync(int id);

    Task<ResponseDto<EmpleadoDto>> CrearOActualizarEmpleadoAsync(EmpleadoDto dto);
    Task<ResponseDto<string>> EliminarEmpleadoAsync(int id);

    Task<IEnumerable<EmpleadoDto>> ListarEmpleadosPaginadosAsync(int pagina, int tamanioPagina);

    Task<IEnumerable<EmpleadoDto>> FiltrarEmpleadosAsync(string nombre, string apellido, int pagina, int tamanioPagina);


}
