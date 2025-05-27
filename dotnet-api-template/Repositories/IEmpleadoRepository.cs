using dotnet_api_template.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Repositories;
public interface IEmpleadoRepository
{
    Task<IEnumerable<Empleado>> GetAllAsync();
    Task<Empleado> GetByIdAsync(int id);
}