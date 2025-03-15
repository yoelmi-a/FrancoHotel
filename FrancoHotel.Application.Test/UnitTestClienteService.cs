
using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FrancoHotel.Application.Test
{
    public class UnitTestClienteService
    {
        private readonly ClienteService _clienteService;
        public UnitTestClienteService()
        {
            var mockLogger = MocksTest.GetLoggerMock<ClienteService>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _clienteService = new ClienteService(mockContext, mockLogger.Object, mockConfiguration);
        }

        //Save 

        [Fact]
        public async void Save_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            SaveClienteDtos cliente = null;

            // Act
            string message = "Los datos del cliente son inválidos";
            var result = await _clienteService.Save(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("María123")]
        [InlineData("José-Pérez")]
        [InlineData("Luís_Álvarez")]
        public async void Save_ShouldReturnFailure_WhenNombreIsInvalid(string nombre)
        {
            // Arrange
            SaveClienteDtos cliente = new SaveClienteDtos
            {
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = nombre,
                Correo = "juan.perez@example.com",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            // Act
            string message = "El nombre completo es inválido";
            var result = await _clienteService.Save(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("123A")]
        [InlineData("45-678")]
        [InlineData("78 90")]
        public async void Save_ShouldReturnFailure_WhenDocumentoIsInvalid(string documento)
        {
            // Arrange
            SaveClienteDtos cliente = new SaveClienteDtos
            {
                TipoDocumento = "DNI",
                Documento = documento,
                NombreCompleto = "Juan",
                Correo = "juan.perez@example.com",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            // Act
            string message = "El documento es inválido";
            var result = await _clienteService.Save(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("usuarioexample.com")]
        [InlineData("usuario@dominio@correo.com")]
        [InlineData("usuario nombre@correo.com")]
        public async void Save_ShouldReturnFailure_WhenCorreoIsInvalid(string correo)
        {
            // Arrange
            SaveClienteDtos cliente = new SaveClienteDtos
            {
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan",
                Correo = correo,
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            // Act
            string message = "El correo es inválido";
            var result = await _clienteService.Save(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Update
    }
}