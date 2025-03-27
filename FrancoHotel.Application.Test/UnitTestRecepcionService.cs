
using Castle.Components.DictionaryAdapter;
using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Dtos.RecepcionDtos;
using FrancoHotel.Application.Interfaces;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace FrancoHotel.Application.Test
{
    public class UnitTestRecepcionService
    {
        private readonly RecepcionService _recepcionService;
        private readonly Mock<IRecepcionRepository> _recepcionRepositoryMock;
        private readonly Mock<IRecepcionMapper> _recepcionMapperMock;

        public UnitTestRecepcionService()
        {
            _recepcionRepositoryMock = new Mock<IRecepcionRepository>();
            _recepcionMapperMock = new Mock<IRecepcionMapper>();

            _recepcionService = new RecepcionService(
                _recepcionRepositoryMock.Object,
                Mocks.GetLoggerMock<RecepcionService>().Object,
                Mocks.GetConfigurationBuilderGerardo(),
                _recepcionMapperMock.Object
            );
        }

        //---------------------//
        //Save
        //--------------------//

        [Fact]
        public async Task Save_ShouldReturnFailure_WhenRecepcionExist()
        {
            DateTime fechaInicio = new DateTime(2024, 2, 11, 14, 30, 0);
            DateTime fechaFinal = new DateTime(2024, 2, 16, 14, 30, 0);

            // Arrange
            SaveRecepcionDto recepcion = new SaveRecepcionDto
            {
                IdCliente = 1,
                IdHabitacion = 1,
                FechaEntrada = fechaInicio,
                FechaSalida = fechaFinal,
                PrecioInicial = 100,
                Adelanto = 50,
                PrecioRestante = 50,
                TotalPagado = 50,
                CostoPenalidad = 20,
                Observacion = "string",
                Estado = (EstadoReserva)1,
                CantidadPersonas = 1,
                IdServicioPorCategoria = 1,
                PrecioServiciosExtra = 0,
            };

            // Act
            string message = "Error reserva ocupada";
            var result = await _recepcionService.Save(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async Task Save_ShouldReturnFailure_WhenRecepcionFechaIsNull()
        {
            DateTime fechaInicio = new DateTime(2023, 2, 11, 14, 30, 0);
            DateTime fechaFinal = new DateTime(2023, 2, 16, 14, 30, 0);

            // Arrange
            SaveRecepcionDto recepcion = new SaveRecepcionDto
            {
                IdCliente = 1,
                IdHabitacion = 1,
                FechaEntrada = fechaInicio,
                FechaSalida = fechaFinal,
                PrecioInicial = 100,
                Adelanto = 50,
                PrecioRestante = 50,
                TotalPagado = 50,
                CostoPenalidad = 20,
                Observacion = "string",
                Estado = (EstadoReserva)1,
                CantidadPersonas = 1,
                IdServicioPorCategoria = 1,
                PrecioServiciosExtra = 0,
            };

            // Act
            string message = "Recepcion no guardado por fecha antigua";
            var result = await _recepcionService.Save(recepcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    
    }
}
