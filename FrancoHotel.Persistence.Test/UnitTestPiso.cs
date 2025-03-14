using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Context;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestPiso
    {
        private readonly PisoRepository _repository;
        public UnitTestPiso()
        {
            var mockLogger = MocksTest.GetLoggerMock<PisoRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _repository = new PisoRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenPisoIsNull()
        {
            
            //Arange

            Piso piso = null;

            //Act
            string message = "Los datos del piso no son validos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange

            Piso piso = new Piso();
            piso.EstadoYFecha.Estado = true;
            piso.Descripcion = data;
            piso.EstadoYFecha.FechaCreacion = DateTime.Now;
            piso.CreadorPorU = 1;

            //Act
            string message = "Los datos del piso no son validos";
            var result = await _repository.SaveEntityAsync(piso);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
