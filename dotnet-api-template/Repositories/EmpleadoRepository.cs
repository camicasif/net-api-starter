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
            await _context.Empleados
                .Where(e => !e.Deleted)
                .ToListAsync();

    public async Task<IEnumerable<Empleado>> GetEmpleadosPaginadosAsync(int pagina, int tamanioPagina)
    {
        return await _context.Empleados
            .Where(e => !e.Deleted)
            .Skip((pagina - 1) * tamanioPagina)
            .Take(tamanioPagina)
            .ToListAsync();
    }

    public async Task<Empleado?> GetByIdAsync(int id) =>
        await _context.Empleados
            .FirstOrDefaultAsync(e => e.Id == id && !e.Deleted);


    public async Task<Empleado?> ObtenerPorIdAsync(int id) =>
        await _context.Empleados
            .FirstOrDefaultAsync(e => e.Id == id && !e.Deleted);

    public async Task InsertarAsync(Empleado empleado)
    {
        _context.Empleados.Add(empleado);
        await _context.SaveChangesAsync();
    }

    public async Task ActualizarAsync(Empleado empleado)
    {
        _context.Empleados.Update(empleado);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DniExisteAsync(string dni, int? excluirId = null)
    {
        return await _context.Empleados
            .AnyAsync(e =>
                e.Dni == dni &&
                !e.Deleted &&
                (!excluirId.HasValue || e.Id != excluirId.Value)
            );
    }

    public async Task EliminarLogicamenteAsync(int id)
    {
        var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == id && !e.Deleted);

        if (empleado == null)
            throw new KeyNotFoundException("El empleado no existe o ya fue eliminado.");

        empleado.Deleted = true;
        await _context.SaveChangesAsync();
    }
}
