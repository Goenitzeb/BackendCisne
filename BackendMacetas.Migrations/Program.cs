using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;

namespace BackendMacetas.Migrations
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=macetas_db;Username=postgres;Password=password;Include Error Detail=true";

            // ¡Agregamos un pequeño menú interactivo!
            Console.WriteLine("=== GESTOR DE BASE DE DATOS ===");
            Console.WriteLine("1. Aplicar todas las migraciones pendientes (Migrate Up)");
            Console.WriteLine("2. Revertir la ÚLTIMA migración (Rollback 1 paso)");
            Console.WriteLine("3. Borrar TODAS las tablas (Migrate Down a 0)");
            Console.Write("Elige una opción (1, 2 o 3): ");
            var opcion = Console.ReadLine();

            var serviceProvider = new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Program).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);

            using (var scope = serviceProvider.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

                try
                {
                    Console.WriteLine("\nEjecutando orden...");

                    if (opcion == "1")
                    {
                        runner.MigrateUp();
                        Console.WriteLine("¡Migraciones aplicadas con éxito! <:3");
                    }
                    else if (opcion == "2")
                    {
                        // Revierte solo la última ejecución
                        runner.Rollback(1);
                        Console.WriteLine("¡Última migración revertida con éxito!");
                    }
                    else if (opcion == "3")
                    {
                        // El 0 le indica que revierta TODO hasta el inicio
                        runner.MigrateDown(0);
                        Console.WriteLine("¡Todas las tablas fueron borradas con éxito!");
                    }
                    else
                    {
                        Console.WriteLine("Opción no válida.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error en la base de datos: {ex.Message}");
                }
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}