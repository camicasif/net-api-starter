using Microsoft.EntityFrameworkCore;
using Bogus;
using dotnet_api_template.Data;

public static class DataInitializer
{
    public static void Seed(VentasDbContext context)
    {
        if (!context.Empleados.Any())
        {
            var faker = new Faker<Empleado>("es")
                .RuleFor(e => e.Nombre, f => f.Name.FirstName())
                .RuleFor(e => e.Apellido, f => f.Name.LastName())
                .RuleFor(e => e.FechaNacimiento, f => f.Date.Between(new DateTime(1960, 1, 1), new DateTime(2002, 12, 31)))
                .RuleFor(e => e.Dni, f => f.Random.Number(1000000, 9999999).ToString())
                .RuleFor(e => e.Sueldo, f => f.Random.Int(3500, 30000))
                .RuleFor(e => e.TieneSeguroPrivado, f => f.Random.Bool());

            var empleados = faker.Generate(100);

            context.Empleados.AddRange(empleados);
            context.SaveChanges();
        }
    }
}
