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
    public class BuildingRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private BuildingRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitOfWork = new UnitOfWork(_context);
            _repository = new BuildingRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddBuilding()
        {
            // Arrange
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = Guid.NewGuid(), Address = address, BuildingNumber = 1 };

            // Act
            _repository.Add(building);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado un edificio.");
            Assert.AreEqual(building.Address.Address, result[0].Address.Address, "La dirección del edificio no coincide.");
            Assert.AreEqual(building.BuildingNumber, result[0].BuildingNumber, "El número del edificio no coincide.");
        }

        [TestMethod]
        public void GetById_ShouldReturnBuilding()
        {
            // Arrange
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = Guid.NewGuid(), Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetById(building.Id);

            // Assert
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");
            Assert.AreEqual(building.Address.Address, result.Address.Address, "La dirección del edificio no coincide.");
            Assert.AreEqual(building.BuildingNumber, result.BuildingNumber, "El número del edificio no coincide.");
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllBuildings()
        {
            // Arrange
            var address1 = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var address2 = new PhysicalAddress("Cuba", "La Habana", "6ta Avenida");
            var building1 = new Building { Id = Guid.NewGuid(), Address = address1, BuildingNumber = 1 };
            var building2 = new Building { Id = Guid.NewGuid(), Address = address2, BuildingNumber = 2 };
            _context.Buildings.Add(building1);
            _context.Buildings.Add(building2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count, "Se deben devolver dos edificios.");
            Assert.IsTrue(result.Any(b => b.Id == building1.Id), "El primer edificio no se encuentra en la lista.");
            Assert.IsTrue(result.Any(b => b.Id == building2.Id), "El segundo edificio no se encuentra en la lista.");
        }

        [TestMethod]
        public void Update_ShouldModifyBuilding()
        {
            // Arrange
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = Guid.NewGuid(), Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges();

            // Act
            var newAddress = new PhysicalAddress("Cuba", "La Habana", "789 Oak St");
            building.Address = newAddress;
            _repository.Update(building);
            _unitOfWork.SaveChanges();

            // Assert
            var updatedBuilding = _repository.GetById(building.Id);
            Assert.AreEqual(newAddress.Address, updatedBuilding.Address.Address, "La dirección del edificio no se actualizó correctamente.");
            Assert.AreEqual(building.BuildingNumber, updatedBuilding.BuildingNumber, "El número del edificio no debe cambiar.");
        }

        [TestMethod]
        public void Delete_ShouldRemoveBuilding()
        {
            // Arrange
            var address = new PhysicalAddress("Cuba", "La Habana", "5ta Avenida");
            var building = new Building { Id = Guid.NewGuid(), Address = address, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges();

            // Act
            _repository.Delete(building.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetById(building.Id);
            Assert.IsNull(result, "El edificio no debe existir después de ser eliminado.");
        }
    }
}