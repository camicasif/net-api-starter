using dotnet_api_template.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dotnet_api_template.Repositories;


public class EmpleadoRepository : IEmpleadoRepository
{
    private readonly VentasDbContext _context;

    public EmpleadoRepository(VentasDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Empleado>> GetAllAsync() =>
        await _context.Empleados.ToListAsync();

    public async Task<Empleado> GetByIdAsync(int id) =>
        await _context.Empleados.FindAsync(id);
}
