using dotnet_api_template.Data;
using dotnet_api_template.DTOs;
using dotnet_api_template.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_api_template.Services;

public class EmpleadoService : IEmpleadoService
{
    private readonly IEmpleadoRepository _repo;

    public EmpleadoService(IEmpleadoRepository repository)
    {
        _repo = repository; 
    }

    public async Task<IEnumerable<EmpleadoDto>> ObtenerTodosAsync()
    {
        var empleados = await _repo.GetAllAsync();
        return empleados.Select(e => new EmpleadoDto
        {
            Nombre = e.Nombre,
            Sueldo = e.Sueldo
        });
    }

    public async Task<EmpleadoDto> ObtenerPorIdAsync(int id)
    {
        var e = await _repo.GetByIdAsync(id);
        return new EmpleadoDto
        {
            Nombre = $"{e.Nombre} {e.Apellido}",
            Sueldo = e.Sueldo
        };
    }


    public async Task<ResponseDto<EmpleadoDto>> CrearOActualizarEmpleadoAsync(EmpleadoDto dto)
    {
        if (dto.FechaNacimiento.AddYears(18) > DateTime.Today)
            return ResponseDto<EmpleadoDto>.Fail("El empleado debe ser mayor de edad.");

        //if (dto.Sueldo <= 0 || dto.Sueldo > 999999)
        //    return ResponseDto<EmpleadoDto>.Fail("El sueldo debe ser un número positivo menor a 1 millón.");

        var dniExiste = await _repo.DniExisteAsync(dto.Dni, dto.Id);
        if (dniExiste)
            return ResponseDto<EmpleadoDto>.Fail("El DNI ya está registrado.");

        dto.Nombre = dto.Nombre?.Trim();
        dto.Apellido = dto.Apellido?.Trim();
        dto.Dni = dto.Dni?.Trim();

        if (dto.Id == null)
        {

            // Crear
            var nuevo = new Empleado
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaNacimiento = dto.FechaNacimiento,
                Dni = dto.Dni,
                Sueldo = dto.Sueldo,
                TieneSeguroPrivado = dto.TieneSeguroPrivado
            };

            await _repo.InsertarAsync(nuevo);

            dto.Id = nuevo.Id;
            return ResponseDto<EmpleadoDto>.Success(dto);
        }
        else
        {
            // Actualizar
            var existente = await _repo.ObtenerPorIdAsync(dto.Id.Value);
            if (existente == null)
                return ResponseDto<EmpleadoDto>.Fail("El empleado no existe.");

            existente.Nombre = dto.Nombre;
            existente.Apellido = dto.Apellido;
            existente.FechaNacimiento = dto.FechaNacimiento;
            existente.Dni = dto.Dni;
            existente.Sueldo = dto.Sueldo;
            existente.TieneSeguroPrivado = dto.TieneSeguroPrivado;

            await _repo.ActualizarAsync(existente);

            return ResponseDto<EmpleadoDto>.Success(dto);
        }
    }
}
