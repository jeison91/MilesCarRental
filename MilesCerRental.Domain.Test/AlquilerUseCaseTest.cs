using MilesCarRental.Domain.Exceptions;
using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.Model;
using MilesCarRental.Domain.UseCase;
using Moq;
using System.Reflection;

namespace MilesCerRental.Domain.Test
{
    [TestClass]
    public class AlquilerUseCaseTest
    {
        [TestMethod]
        public async Task CreateRentailFull()
        {
            // Arrange
            var alquilerModel = new AlquilerModel
            {
                Id = 4,
                IdCliente = 1,
                IdVehiculo = 3,
                IdlocalidadRecoge = 1,
                IdLocalidadEntrega = 2,
                FechaRecoge = DateTime.Parse("2024-03-01"),
                HoraRecoge = 10,
                FechaEntrega = DateTime.Parse("2024-03-04"),
                HoraEntrega = 12
            };


            var mockAlquilerRepository = new Mock<IAlquilerRepository>();
            mockAlquilerRepository.Setup(repo => repo.CreateRentalAsync(It.IsAny<AlquilerModel>()))
                                  .ReturnsAsync(alquilerModel);

            var mockVehiculoRepository = new Mock<IVehiculoRepository>();

            mockVehiculoRepository
                .Setup(p => p.AvailableCarsAsync(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new List<VehiculoModel>
                {
                    new VehiculoModel
                    {
                        Id = 1,
                        Placa = "AAQ 365",
                        Modelo = 2016,
                        IdMarca = 1,
                        IdLocalidadActual = 3
                    }
                }));

            var sut = new AlquilerUseCase(mockAlquilerRepository.Object, mockVehiculoRepository.Object);

            VehiculoModel vehiculoModel = new()
            {
                Id = 1,
                Placa = "AAQ 365",
                Modelo = 2016,
                IdMarca = 1,
                IdLocalidadActual = 3
            };

            mockVehiculoRepository
                .Setup(p => p.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(vehiculoModel));

            mockVehiculoRepository.Setup(repo => repo.Update(It.IsAny<VehiculoModel>()))
                                  .ReturnsAsync(vehiculoModel);

            // Act
            var result = await sut.CreateRental(alquilerModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.IdCliente);
            Assert.AreEqual(3, result.IdVehiculo);
            Assert.AreEqual(1, result.IdlocalidadRecoge);
            Assert.AreEqual(2, result.IdLocalidadEntrega);
            Assert.AreEqual(DateTime.Parse("2024-03-01"), result.FechaRecoge);
            Assert.AreEqual(DateTime.Parse("2024-03-04"), result.FechaEntrega);
        }

        [TestMethod]
        public async Task CreateRentail_CarsNotAvaliable()
        {
            // Arrange
            var alquilerModel = new AlquilerModel
            {
                Id = 4,
                IdCliente = 1,
                IdVehiculo = 3,
                IdlocalidadRecoge = 1,
                IdLocalidadEntrega = 2,
                FechaRecoge = DateTime.Parse("2024-03-01"),
                HoraRecoge = 10,
                FechaEntrega = DateTime.Parse("2024-03-04"),
                HoraEntrega = 12
            };


            var mockAlquilerRepository = new Mock<IAlquilerRepository>();
            mockAlquilerRepository.Setup(repo => repo.CreateRentalAsync(It.IsAny<AlquilerModel>()))
                                  .ReturnsAsync(alquilerModel);

            var mockVehiculoRepository = new Mock<IVehiculoRepository>();

            mockVehiculoRepository
                .Setup(p => p.AvailableCarsAsync(It.IsAny<DateTime>(), It.IsAny<int>()))
                .Returns(Task.FromResult(new List<VehiculoModel>()));

            var sut = new AlquilerUseCase(mockAlquilerRepository.Object, mockVehiculoRepository.Object);

            // Act
            var exception = await Assert.ThrowsExceptionAsync<DomainValidateException>(async () =>
            {
                await sut.CreateRental(alquilerModel);
            });


            // Assert
            Assert.IsNotNull(exception);
            Assert.AreEqual("No hay vehiculos disponibles.", exception.Message);
        }
    }
}