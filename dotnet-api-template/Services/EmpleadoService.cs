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


    public async Task<ResponseDto<EmpleadoDto>> ObtenerEmpleadoPorIdAsync(int id)
    {
        var empleado = await _repo.ObtenerPorIdAsync(id);

        if (empleado == null || empleado.Deleted)
            return ResponseDto<EmpleadoDto>.Fail("El empleado no existe.");

        var dto = new EmpleadoDto
        {
            Id = empleado.Id,
            Nombre = empleado.Nombre,
            Apellido = empleado.Apellido,
            FechaNacimiento = empleado.FechaNacimiento,
            Dni = empleado.Dni,
            Sueldo = empleado.Sueldo,
            TieneSeguroPrivado = empleado.TieneSeguroPrivado
        };

        return ResponseDto<EmpleadoDto>.Success(dto);
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


    public async Task<ResponseDto<string>> EliminarEmpleadoAsync(int id)
    {
        try
        {
            await _repo.EliminarLogicamenteAsync(id);
            return ResponseDto<string>.Success("Empleado eliminado correctamente.");
        }
        catch (KeyNotFoundException ex)
        {
            return ResponseDto<string>.Fail(ex.Message);
        }
    }

    public async Task<IEnumerable<EmpleadoDto>> ListarEmpleadosPaginadosAsync(int pagina, int tamanioPagina)
    {
        var empleados = await _repo.GetEmpleadosPaginadosAsync(pagina, tamanioPagina);

        return empleados.Select(e => new EmpleadoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            FechaNacimiento = e.FechaNacimiento,
            Dni = e.Dni,
            Sueldo = e.Sueldo,
            TieneSeguroPrivado = e.TieneSeguroPrivado
        });
    }

    public async Task<IEnumerable<EmpleadoDto>> FiltrarEmpleadosAsync(string nombre, string apellido, int pagina, int tamanioPagina)
    {
        var empleados = await _repo.FiltrarPorNombreApellidoAsync(nombre, apellido, pagina, tamanioPagina);

        return empleados.Select(e => new EmpleadoDto
        {
            Id = e.Id,
            Nombre = e.Nombre,
            Apellido = e.Apellido,
            FechaNacimiento = e.FechaNacimiento,
            Dni = e.Dni,
            Sueldo = e.Sueldo,
            TieneSeguroPrivado = e.TieneSeguroPrivado
        });
    }


}
