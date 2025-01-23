using Grpc.Net.Client;
using EMV.GrpcProto; // Asegúrate de que este espacio de nombres sea correcto
using System;
using System.Net.Http;
using Grpc.Core;

namespace Enviromental_Variables_Measurement.ConsoleApp
{
    /// <summary>Clase principal del programa que ejecuta las operaciones CRUD en la base de datos SQLite.</summary>
    internal class Program
    {
        /// <summary>Método principal del programa.</summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para comenzar....");
            Console.ReadKey();

            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback =
                HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;

            var channel = GrpcChannel.ForAddress(
                "http://localhost:5186",
                new GrpcChannelOptions { HttpHandler = httpHandler });

            if (channel == null)
            {
                Console.WriteLine("Cannot connect");
                channel.Dispose();
                return;
            }

            var client = new RoomService.RoomServiceClient(channel);

            Console.WriteLine("Presione una tecla para crear una habitación");
            Console.ReadKey();

            try
            {
                var createResponse = client.CreateRoom(new CreateRoomRequest()
                {
                    Number = 101, // Número de la habitación
                    IsProduction = false, // Indica si es una habitación de producción
                    Description = "Habitación de pruebas", // Descripción de la habitación
                    FloorId = "some-floor-id" // ID del piso asociado (reemplaza con un ID válido)
                });
                Console.WriteLine("Habitación creada con éxito: " + createResponse.Id);
            }
            catch (RpcException ex)
            {
                Console.WriteLine($"Error al crear la habitación: {ex.Status.Detail}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
            }

            Console.WriteLine("Presione una tecla para salir...");
            Console.ReadKey();
        }
    }
}