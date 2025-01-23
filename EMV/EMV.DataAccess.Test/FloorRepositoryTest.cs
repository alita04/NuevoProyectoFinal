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
    public class FloorRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private FloorRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitOfWork = new UnitOfWork(_context);
            _repository = new FloorRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddFloor()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 }; // Asegúrate de que la clase Building tenga estas propiedades

            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floor = new Floor { Id = Guid.NewGuid(), Location = "First Floor", Building_Id = buildingId };

            // Act
            _repository.Add(floor);

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado un piso.");
            Assert.AreEqual(floor.Location, result[0].Location, "La ubicación del piso no coincide.");
            Assert.AreEqual(floor.Building_Id, result[0].Building_Id, "El ID del edificio del piso no coincide.");
        }

        [TestMethod]
        public void GetById_ShouldReturnFloor()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floor = new Floor { Id = Guid.NewGuid(), Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetById(floor.Id);

            // Assert
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");
            Assert.AreEqual(floor.Location, result.Location, "La ubicación del piso no coincide.");
            Assert.AreEqual(floor.Building_Id, result.Building_Id, "El ID del edificio del piso no coincide.");
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllFloors()
        {
            // Arrange
            var buildingId1 = Guid.NewGuid(); // Simulamos un ID de edificio
            var buildingId2 = Guid.NewGuid(); // Simulamos otro ID de edificio
            var address1 = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var address2 = new PhysicalAddress("Cuba", "La Habana", "6ta Avenida");
            var building1 = new Building { Id = buildingId1, Address = address1, BuildingNumber = 1 };
            var building2 = new Building { Id = buildingId2, Address = address2, BuildingNumber = 2 };
            _context.Buildings.Add(building1);
            _context.Buildings.Add(building2);
            _unitOfWork.SaveChanges(); // Guarda los edificios antes de agregar los pisos

            var floor1 = new Floor { Id = Guid.NewGuid(), Location = "First Floor", Building_Id = buildingId1 };
            var floor2 = new Floor { Id = Guid.NewGuid(), Location = "Second Floor", Building_Id = buildingId2 };
            _context.Floors.Add(floor1);
            _context.Floors.Add(floor2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count, "Se deben devolver dos pisos.");
            Assert.IsTrue(result.Any(f => f.Id == floor1.Id), "El primer piso no se encuentra en la lista.");
            Assert.IsTrue(result.Any(f => f.Id == floor2.Id), "El segundo piso no se encuentra en la lista.");
        }

        [TestMethod]
        public void Update_ShouldModifyFloor()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floor = new Floor { Id = Guid.NewGuid(), Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges();

            // Act
            floor.Location = "Updated Floor";
            _repository.Update(floor);

            // Assert
            var updatedFloor = _repository.GetById(floor.Id);
            Assert.AreEqual("Updated Floor", updatedFloor.Location, "La ubicación del piso no se actualizó correctamente.");
            Assert.AreEqual(floor.Building_Id, updatedFloor.Building_Id, "El ID del edificio del piso no debe cambiar.");
        }

        [TestMethod]
        public void Delete_ShouldRemoveFloor()
        {
            // Arrange
            var buildingId = Guid.NewGuid(); // Simulamos un ID de edificio
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = buildingId, Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floor = new Floor { Id = Guid.NewGuid(), Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges();

            // Act
            _repository.Delete(floor.Id);

            // Assert
            var result = _repository.GetById(floor.Id);
            Assert.IsNull(result, "El piso no debe existir después de ser eliminado.");
        }
    }
}