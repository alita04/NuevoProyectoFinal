using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.DataAccess;
using Enviromental_Measurement.DataAccess.Contexts;
using Enviromental_Measurement.DataAccess.Repositories;
using Enviromental_Measurement.Domain.Entities.Structures;
using Enviromental_Measurement.Domain.Entities.Variable;
using Enviromental_Measurement.Domain.Types;
using Enviromental_Measurement.Domain.ValueObjects;
using Enviromental_Variable_Measurement.DataAccess.Tests.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Enviromental_Measurement.DataAccess.Tests
{
    [TestClass]
    public class VariableRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private VariableRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitOfWork = new UnitOfWork(_context);
            _repository = new VariableRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddVariable_WithBuildingID()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Temperature",
                measurement_Unit: new Measurement_Unit("Celsius", "°C"),
                variableCode: "TEMP001",
                type: VariableType.DiscreteVariable,
                buildingID: buildingId, // Asociada a un edificio
                floorID: null,
                roomID: null
            );

            // Act
            _repository.Add(variable);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado una variable.");
            Assert.AreEqual(variable.VariableName, result[0].VariableName, "El nombre de la variable no coincide.");
            Assert.AreEqual(variable.VariableCode, result[0].VariableCode, "El código de la variable no coincide.");
            Assert.AreEqual(variable.BuildingID, result[0].BuildingID, "El ID del edificio de la variable no coincide.");
        }

        [TestMethod]
        public void Add_ShouldAddVariable_WithFloorID()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid();
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Humidity",
                measurement_Unit: new Measurement_Unit("Percentage", "%"),
                variableCode: "HUM001",
                type: VariableType.DiscreteVariable,
                buildingID: null,
                floorID: floorId, // Asociada a un piso
                roomID: null
            );

            // Act
            _repository.Add(variable);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado una variable.");
            Assert.AreEqual(variable.VariableName, result[0].VariableName, "El nombre de la variable no coincide.");
            Assert.AreEqual(variable.VariableCode, result[0].VariableCode, "El código de la variable no coincide.");
            Assert.AreEqual(variable.FloorID, result[0].FloorID, "El ID del piso de la variable no coincide.");
        }

        [TestMethod]
        public void Add_ShouldAddVariable_WithRoomID()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar el piso

            var floorId = Guid.NewGuid();
            var floor = new Floor { Id = floorId, Location = "First Floor", Building_Id = buildingId };
            _context.Floors.Add(floor);
            _unitOfWork.SaveChanges(); // Guarda el piso antes de agregar la habitación

            var roomId = Guid.NewGuid();
            var room = new Room { Id = roomId, Number = 101, IsProduction = false, FloorId = floorId };
            _context.Rooms.Add(room);
            _unitOfWork.SaveChanges(); // Guarda la habitación antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Pressure",
                measurement_Unit: new Measurement_Unit("Pascal", "Pa"),
                variableCode: "PRESS001",
                type: VariableType.DiscreteVariable,
                buildingID: null,
                floorID: null,
                roomID: roomId // Asociada a una habitación
            );

            // Act
            _repository.Add(variable);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetAll().ToList();
            Assert.AreEqual(1, result.Count, "Se debe haber agregado una variable.");
            Assert.AreEqual(variable.VariableName, result[0].VariableName, "El nombre de la variable no coincide.");
            Assert.AreEqual(variable.VariableCode, result[0].VariableCode, "El código de la variable no coincide.");
            Assert.AreEqual(variable.RoomID, result[0].RoomID, "El ID de la habitación de la variable no coincide.");
        }

        [TestMethod]
        public void GetById_ShouldReturnVariable()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Temperature",
                measurement_Unit: new Measurement_Unit("Celsius", "°C"),
                variableCode: "TEMP001",
                type: VariableType.DiscreteVariable,
                buildingID: buildingId,
                floorID: null,
                roomID: null
            );
            _context.Variables.Add(variable);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetById(variable.Id);

            // Assert
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");
            Assert.AreEqual(variable.VariableName, result.VariableName, "El nombre de la variable no coincide.");
            Assert.AreEqual(variable.VariableCode, result.VariableCode, "El código de la variable no coincide.");
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllVariables()
        {
            // Arrange
            var buildingId1 = Guid.NewGuid();
            var building1 = new Building { Id = buildingId1, BuildingNumber = 1 };
            _context.Buildings.Add(building1);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar la variable

            var variable1 = new Variable(
                id: Guid.NewGuid(),
                variableName: "Temperature",
                measurement_Unit: new Measurement_Unit("Celsius", "°C"),
                variableCode: "TEMP001",
                type: VariableType.DiscreteVariable,
                buildingID: buildingId1,
                floorID: null,
                roomID: null
            );

            var variable2 = new Variable(
                id: Guid.NewGuid(),
                variableName: "Humidity",
                measurement_Unit: new Measurement_Unit("Percentage", "%"),
                variableCode: "HUM001",
                type: VariableType.DiscreteVariable,
                buildingID: null,
                floorID: null,
                roomID: null
            );

            _context.Variables.Add(variable1);
            _context.Variables.Add(variable2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _repository.GetAll().ToList();

            // Assert
            Assert.AreEqual(2, result.Count, "Se deben devolver dos variables.");
            Assert.IsTrue(result.Any(v => v.Id == variable1.Id), "La primera variable no se encuentra en la lista.");
            Assert.IsTrue(result.Any(v => v.Id == variable2.Id), "La segunda variable no se encuentra en la lista.");
        }

        [TestMethod]
        public void Update_ShouldModifyVariable()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Temperature",
                measurement_Unit: new Measurement_Unit("Celsius", "°C"),
                variableCode: "TEMP001",
                type: VariableType.DiscreteVariable,
                buildingID: buildingId,
                floorID: null,
                roomID: null
            );
            _context.Variables.Add(variable);
            _unitOfWork.SaveChanges();

            // Act
            variable.VariableName = "Updated Temperature";
            _repository.Update(variable);
            _unitOfWork.SaveChanges();

            // Assert
            var updatedVariable = _repository.GetById(variable.Id);
            Assert.AreEqual("Updated Temperature", updatedVariable.VariableName, "El nombre de la variable no se actualizó correctamente.");
            Assert.AreEqual(variable.BuildingID, updatedVariable.BuildingID, "El ID del edificio de la variable no debe cambiar.");
        }

        [TestMethod]
        public void Delete_ShouldRemoveVariable()
        {
            // Arrange
            var buildingId = Guid.NewGuid();
            var building = new Building { Id = buildingId, BuildingNumber = 1 };
            _context.Buildings.Add(building);
            _unitOfWork.SaveChanges(); // Guarda el edificio antes de agregar la variable

            var variable = new Variable(
                id: Guid.NewGuid(),
                variableName: "Temperature",
                measurement_Unit: new Measurement_Unit("Celsius", "°C"),
                variableCode: "TEMP001",
                type: VariableType.DiscreteVariable,
                buildingID: buildingId,
                floorID: null,
                roomID: null
            );
            _context.Variables.Add(variable);
            _unitOfWork.SaveChanges();

            // Act
            _repository.Delete(variable.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _repository.GetById(variable.Id);
            Assert.IsNull(result, "La variable no debe existir después de ser eliminada.");
        }
    }
}