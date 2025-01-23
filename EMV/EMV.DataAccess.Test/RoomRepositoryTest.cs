using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.DataAccess;
using Enviromental_Measurement.DataAccess.Contexts;
using Enviromental_Measurement.DataAccess.Repositories;
using Enviromental_Measurement.Domain.Entities.Structures;
using Enviromental_Measurement.Domain.ValueObjects;
using Enviromental_Variable_Measurement.DataAccess.Tests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Enviromental_Variable_Measurement.DataAccess.Tests
{
    [TestClass]
    public class RoomRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private RoomRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitOfWork = new UnitOfWork(_context);
            _repository = new RoomRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddRoom()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid(); // Simulamos un ID de piso
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var room = new Room { Id = Guid.NewGuid(), Number = 101, IsProduction = true, Description = "Production Room", FloorId = floorId };

            // Act
            _repository.Add(room);

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado una habitación.");
            Assert.AreEqual(room.Number, result[0].Number, "El número de la habitación no coincide.");
            Assert.AreEqual(room.IsProduction, result[0].IsProduction, "El estado de producción de la habitación no coincide.");
            Assert.AreEqual(room.Description, result[0].Description, "La descripción de la habitación no coincide.");
            Assert.AreEqual(room.FloorId, result[0].FloorId, "El ID del piso de la habitación no coincide.");
        }

        [TestMethod]
        public void GetById_ShouldReturnRoom()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid(); // Simulamos un ID de piso
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var room = new Room { Id = Guid.NewGuid(), Number = 101, IsProduction = true, Description = "Production Room", FloorId = floorId };
            _context.Rooms.Add(room);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetById(room.Id);

            // Assert
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");
            Assert.AreEqual(room.Number, result.Number, "El número de la habitación no coincide.");
            Assert.AreEqual(room.IsProduction, result.IsProduction, "El estado de producción de la habitación no coincide.");
            Assert.AreEqual(room.Description, result.Description, "La descripción de la habitación no coincide.");
            Assert.AreEqual(room.FloorId, result.FloorId, "El ID del piso de la habitación no coincide.");
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllRooms()
        {
            // Arrange
            var buildingId1 = Guid.NewGuid(); // Simulamos un ID de edificio
            var address1 = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building1 = new Building { Id = buildingId1, Address = address1, BuildingNumber = 1 };
            _context.Buildings.Add(building1);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId1 = Guid.NewGuid(); // Simulamos un ID de piso
            var floor1 = new Floor { Id = floorId1, Location = "First Floor", Building_Id = buildingId1 };
            _context.Floors.Add(floor1);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var room1 = new Room { Id = Guid.NewGuid(), Number = 101, IsProduction = true, Description = "Production Room", FloorId = floorId1 };
            var room2 = new Room { Id = Guid.NewGuid(), Number = 102, IsProduction = false, Description = "Meeting Room", FloorId = floorId1 };
            _context.Rooms.Add(room1);
            _context.Rooms.Add(room2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count, "Se deben devolver dos habitaciones.");
            Assert.IsTrue(result.Any(r => r.Id == room1.Id), "La primera habitación no se encuentra en la lista.");
            Assert.IsTrue(result.Any(r => r.Id == room2.Id), "La segunda habitación no se encuentra en la lista.");
        }

        [TestMethod]
        public void Update_ShouldModifyRoom()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid(); // Simulamos un ID de piso
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var room = new Room { Id = Guid.NewGuid(), Number = 101, IsProduction = true, Description = "Production Room", FloorId = floorId };
            _context.Rooms.Add(room);
            _unitOfWork.SaveChanges();

            // Act
            room.Description = "Updated Room Description";
            _repository.Update(room);

            // Assert
            var updatedRoom = _repository.GetById(room.Id);
            Assert.AreEqual("Updated Room Description", updatedRoom.Description, "La descripción de la habitación no se actualizó correctamente.");
            Assert.AreEqual(room.Number, updatedRoom.Number, "El número de la habitación no debe cambiar.");
            Assert.AreEqual(room.IsProduction, updatedRoom.IsProduction, "El estado de producción de la habitación no debe cambiar.");
            Assert.AreEqual(room.FloorId, updatedRoom.FloorId, "El ID del piso de la habitación no debe cambiar.");
        }

        [TestMethod]
        public void Delete_ShouldRemoveRoom()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid(); // Simulamos un ID de piso
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var room = new Room { Id = Guid.NewGuid(), Number = 101, IsProduction = true, Description = "Production Room", FloorId = floorId };
            _context.Rooms.Add(room);
            _unitOfWork.SaveChanges();

            // Act
            _repository.Delete(room.Id);

            // Assert
            var result = _repository.GetById(room.Id);
            Assert.IsNull(result, "La habitación no debe existir después de ser eliminada.");
        }
    }
}