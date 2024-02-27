using MilesCarRental.Domain.Exceptions;
using MilesCarRental.Domain.IRepository;
using MilesCarRental.Domain.Model;
using MilesCarRental.Domain.UseCase;
using Moq;
using System.Reflection;

namespace MilesCerRental.Domain.Test
{
    [TestClass]
    public class VehiculoUseCaseTest
    {
        [TestMethod]
        public async Task GetCarAvaliable()
        {
            DateTime fechaRecoge = new(2024, 03, 04);
            int LocalidaRecoge = 4;

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
                    },
                    new VehiculoModel
                    {
                        Id = 3,
                        Placa = "UTG 123",
                        Modelo = 2022,
                        IdMarca = 2,
                        IdLocalidadActual = 4
                    }
                }));

            var sut = new VehiculoUseCase(mockVehiculoRepository.Object);

            // Act
            var result = await sut.GetAvailable(fechaRecoge, LocalidaRecoge);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.First().Id);
            Assert.AreEqual("AAQ 365", result.First().Placa);
            Assert.AreEqual(2016, result.First().Modelo);
            Assert.AreEqual(1, result.First().IdMarca);
            Assert.AreEqual(3, result.First().IdLocalidadActual);
        }
    }
}