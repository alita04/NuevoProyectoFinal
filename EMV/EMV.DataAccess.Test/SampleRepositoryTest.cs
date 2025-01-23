using Enviromental_Measurement.Contracts;
using Enviromental_Measurement.DataAccess.Contexts;
using Enviromental_Measurement.DataAccess.Repositories;
using Enviromental_Measurement.DataAccess;
using Enviromental_Measurement.Domain.Entities.Samples;

using Enviromental_Variable_Measurement.DataAccess.Tests.Utilities;
using Enviromental_Measurement.Domain.Types;
using Enviromental_Measurement.Domain.Entities.Variable;

namespace Enviromental_Variable_Measurement.DataAccess.Tests
{
    [TestClass]
    public class SampleRepositoryTests
    {
        private ApplicationContext _context;
        private IUnitOfWork _unitOfWork;
        private SampleRepository _sampleRepository;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ApplicationContext(ConnectionStringProvider.GetConnectionString());
            _unitOfWork = new UnitOfWork(_context);
            _sampleRepository = new SampleRepository(_context);

            // Limpia y recrea la base de datos
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Add_ShouldAddSample()
        {
            // Arrange
            var variable = new Variable
            {
                Id = Guid.NewGuid(),
                VariableName = "Test Variable",
                VariableCode = "TV001",
                type = VariableType.DiscreteVariable // Asegúrate de que el tipo sea válido
            };

            _context.Set<Variable>().Add(variable);
            _unitOfWork.SaveChanges(); // Guarda el Variable en la base de datos

            var sample = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                VariableId = variable.Id, // Usa el ID del Variable que acabas de crear
                type = SampleType.DiscreteSample
            };

            // Act
            _sampleRepository.Add(sample);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _context.Set<Sample>().FirstOrDefault(s => s.Id == sample.Id);

            // Verificar que el resultado no sea nulo
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");

            // Verificar que el ID coincida
            Assert.AreEqual(sample.Id, result.Id, "El ID del Sample devuelto no coincide con el ID esperado.");

            // Verificar que las propiedades coincidan
            Assert.AreEqual(sample.DateTime, result.DateTime, "La fecha y hora del Sample devuelto no coinciden.");
            Assert.AreEqual(sample.VariableId, result.VariableId, "El VariableId del Sample devuelto no coincide con el esperado.");
            Assert.AreEqual(sample.type, result.type, "El tipo del Sample devuelto no coincide con el esperado.");

            // Verificar que el VariableId del Sample devuelto corresponde a un Variable existente
            var retrievedVariable = _context.Set<Variable>().Find(result.VariableId);
            Assert.IsNotNull(retrievedVariable, "El VariableId del Sample devuelto no corresponde a un Variable existente.");
            Assert.AreEqual(variable.Id, retrievedVariable.Id, "El VariableId del Sample devuelto no coincide con el Variable creado.");

            // Verificar que solo se haya creado un registro en la tabla Samples
            var allSamplesCount = _context.Set<Sample>().Count();
            Assert.AreEqual(1, allSamplesCount, "Se debe haber creado exactamente un Sample en la base de datos.");

            // Verificar que no se haya creado un nuevo registro en la tabla Variables
            var allVariablesCount = _context.Set<Variable>().Count();
            Assert.AreEqual(1, allVariablesCount, "No se debe haber creado un nuevo Variable en la base de datos.");
        }

        [TestMethod]
        public void GetById_ShouldReturnSample()
        {
            // Arrange
            var variable = new Variable
            {
                Id = Guid.NewGuid(),
                VariableName = "Test Variable",
                VariableCode = "TV001",
                type = VariableType.DiscreteVariable
            };

            _context.Set<Variable>().Add(variable);
            _unitOfWork.SaveChanges(); // Guarda el Variable en la base de datos

            var sample = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                VariableId = variable.Id, // Usa el ID del Variable que acabas de crear
            };

            _context.Set<Sample>().Add(sample);
            _unitOfWork.SaveChanges();

            // Act
            var result = _sampleRepository.GetById(sample.Id);

            // Assert
            Assert.IsNotNull(result, "El resultado no debe ser nulo.");
            Assert.AreEqual(sample.Id, result.Id, "El ID del Sample devuelto no coincide con el ID esperado.");

            // Comprobaciones adicionales
            Assert.AreEqual(sample.DateTime, result.DateTime, "La fecha y hora del Sample devuelto no coinciden.");
            Assert.AreEqual(sample.VariableId, result.VariableId, "El VariableId del Sample devuelto no coincide con el esperado.");

            // Verificar que el VariableId del Sample devuelto corresponde a un Variable existente
            var retrievedVariable = _context.Set<Variable>().Find(result.VariableId);
            Assert.IsNotNull(retrievedVariable, "El VariableId del Sample devuelto no corresponde a un Variable existente.");
            Assert.AreEqual(variable.Id, retrievedVariable.Id, "El VariableId del Sample devuelto no coincide con el Variable creado.");
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllSamples()
        {
            // Arrange
            var variable = new Variable
            {
                Id = Guid.NewGuid(),
                VariableName = "Test Variable",
                VariableCode = "TV001",
                type = VariableType.DiscreteVariable,
            };

            _context.Set<Variable>().Add(variable);
            _unitOfWork.SaveChanges(); // Guarda el Variable en la base de datos

            var sample1 = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                VariableId = variable.Id, // Usa el ID del Variable que acabas de crear
            };
            var sample2 = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now.AddMinutes(1),
                VariableId = variable.Id, // Usa el mismo ID del Variable
            };

            _context.Set<Sample>().Add(sample1);
            _unitOfWork.SaveChanges();

            _context.Set<Sample>().Add(sample2);
            _unitOfWork.SaveChanges();

            // Act
            var result = _sampleRepository.GetAll();
            var returnedSample1 = result.First(s => s.Id == sample1.Id);

            var returnedSample2 = result.First(s => s.Id == sample2.Id);

            // Assert
            // Verificar que las propiedades coincidan

            Assert.AreEqual(sample1.DateTime, returnedSample1.DateTime);

            Assert.AreEqual(sample1.VariableId, returnedSample1.VariableId);



            Assert.AreEqual(sample2.DateTime, returnedSample2.DateTime);

            Assert.AreEqual(sample2.VariableId, returnedSample2.VariableId);
            Assert.AreEqual(2, result.Count());
            
        }

        [TestMethod]
        public void Update_ShouldModifySample()
        {
            // Arrange
            var variable = new Variable
            {
                Id = Guid.NewGuid(),
                VariableName = "Test Variable",
                VariableCode = "TV001",
                type = VariableType.DiscreteVariable,
            };

            _context.Set<Variable>().Add(variable);
            _unitOfWork.SaveChanges(); // Guarda el Variable en la base de datos

            var sample = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                VariableId = variable.Id, // Usa el ID del Variable que acabas de crear
            };
            _context.Set<Sample>().Add(sample);
            _unitOfWork.SaveChanges();

            // Act
            sample.DateTime = DateTime.Now.AddHours(1);
            _sampleRepository.Update(sample);
            _unitOfWork.SaveChanges();

            // Assert
            var updatedSample = _sampleRepository.GetById(sample.Id);
            Assert.AreEqual(DateTime.Now.AddHours(1).Hour, updatedSample.DateTime.Hour);
            Assert.AreEqual(DateTime.Now.AddHours(1).Date, updatedSample.DateTime.Date); // Verificar la fecha completa


            // Verificar que el VariableId no cambie

            Assert.AreEqual(variable.Id, updatedSample.VariableId);


            // Verificar que el Id no cambie

            Assert.AreEqual(sample.Id, updatedSample.Id);


            // Verificar que las propiedades no modificadas permanezcan iguales

            Assert.AreEqual(sample.VariableId, updatedSample.VariableId);
        }

        [TestMethod]
        public void Delete_ShouldRemoveSample()
        {
            // Arrange
            var variable = new Variable
            {
                Id = Guid.NewGuid(),
                VariableName = "Test Variable",
                VariableCode = "TV001",
                type = VariableType.DiscreteVariable,
            };

            _context.Set<Variable>().Add(variable);
            _unitOfWork.SaveChanges(); // Guarda el Variable en la base de datos

            var sample = new Sample
            {
                Id = Guid.NewGuid(),
                DateTime = DateTime.Now,
                VariableId = variable.Id, // Usa el ID del Variable que acabas de crear
            };
            _context.Set<Sample>().Add(sample);
            _unitOfWork.SaveChanges();

            // Act
            _sampleRepository.Delete(sample.Id);
            _unitOfWork.SaveChanges();

            // Assert
            var result = _sampleRepository.GetById(sample.Id);
            Assert.IsNull(result);
        }
    }
}