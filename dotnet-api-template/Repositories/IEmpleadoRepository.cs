using dotnet_api_template.Data;
using dotnet_api_template.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Repositories;
public interface IEmpleadoRepository
{
    Task<IEnumerable<Empleado>> GetAllAsync();
    Task<Empleado> GetByIdAsync(int id);

    Task InsertarAsync(Empleado empleado);
    Task ActualizarAsync(Empleado empleado);
    Task<Empleado?> ObtenerPorIdAsync(int id);
    Task<bool> DniExisteAsync(string dni, int? excluirId = null);

    Task EliminarLogicamenteAsync(int id);
    Task<IEnumerable<Empleado>> GetEmpleadosPaginadosAsync(int pagina, int tamanioPagina);
}