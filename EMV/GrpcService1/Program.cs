using MediatR;
using Microsoft.Extensions.Logging;
using EMV.Contracts;
using EMV.DataAccess.Contexts;
using EMV.DataAccess;
using EMV.GrpcProtos;
using System.Reflection.Metadata;
using EMV.DataAccess.Repositories;


namespace Enviromental_Variable_Measurement.GrpcService1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton("Data Source=maintenance_calibration_systemDB.sqlite");
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IBuildingRepository, BuildingRepository>();
            builder.Services.AddScoped<IFloorRepository, FloorRepository>();
            builder.Services.AddScoped<IRoomRepository, RoomRepository>();
            builder.Services.AddScoped<IVariableRepository, VariableRepository>();
            builder.Services.AddScoped<ISampleRepository, SampleRepository>();
           
            builder.Services.AddGrpc();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            builder.Services.AddMediatR(new MediatRServiceConfiguration()
            {
                AutoRegisterRequestProcessors = true,
            }
            .RegisterServicesFromAssemblies(typeof(AssemblyReference).Assembly));

            // Agregar servicios al contenedor
            builder.Services.AddLogging();
            builder.Logging.AddConsole(); // Esto permite que los logs se muestren en la consola
            builder.Logging.AddDebug(); // Esto permite que los logs se muestren en la ventana de salida de Visual Studio

            builder.Services.AddGrpc(options =>
            {
                options.EnableDetailedErrors = true; // Esto habilita los errores detallados
            });

            // Asegurar que ILogger<T> está registrado
            builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            app.MapGrpcService<BuildingServices>(); // Mapea el servicio de edificios
            app.MapGrpcService<FloorServices>(); // Mapea el servicio de pisos
            app.MapGrpcService<RoomServices>(); // Mapea el servicio de habitaciones
            app.MapGrpcService<SampleServices>(); // Mapea el servicio de muestras
            app.MapGrpcService<VariableServices>(); // Mapea el servicio de variables

            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

            app.Run();
        }
    }
}