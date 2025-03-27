using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;

namespace FrancoHotel.Application.Test
{
    public class UnitTestClienteService
    {
        private readonly ClienteService _clienteService;
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly Mock<IClienteMapper> _clienteMapperMock;

        public UnitTestClienteService()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteMapperMock = new Mock<IClienteMapper>();

            _clienteService = new ClienteService(
                _clienteRepositoryMock.Object,
                _clienteMapperMock.Object,
                MocksTest.GetLoggerMock<ClienteService>().Object,
                MocksTest.GetConfigurationBuilderELi()
            );
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

        [Fact]
        public async void Update_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            UpdateClienteDtos cliente = null;

            // Act
            string message = "Los datos del cliente son inválidos";
            var result = await _clienteService.Update(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("María123")]
        [InlineData("José-Pérez")]
        [InlineData("Luís_Álvarez")]
        public async void Update_ShouldReturnFailure_WhenNombreIsInvalid(string nombre)
        {
            // Arrange
            UpdateClienteDtos cliente = new UpdateClienteDtos
            {
                IdCliente = 1,
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
            var result = await _clienteService.Update(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("123A")]
        [InlineData("45-678")]
        [InlineData("78 90")]
        public async void Update_ShouldReturnFailure_WhenDocumentoIsInvalid(string documento)
        {
            // Arrange
            UpdateClienteDtos cliente = new UpdateClienteDtos
            {
                IdCliente = 1,
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
            var result = await _clienteService.Update(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("usuarioexample.com")]
        [InlineData("usuario@dominio@correo.com")]
        [InlineData("usuario nombre@correo.com")]
        public async void Update_ShouldReturnFailure_WhenCorreoIsInvalid(string correo)
        {
            // Arrange
            UpdateClienteDtos cliente = new UpdateClienteDtos
            {
                IdCliente = 1,
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
            var result = await _clienteService.Update(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateTipoDocumento

        [Fact]
        public async Task UpdateTipoDocumento_ShouldReturnFailure_WhenClienteDoesNotExist()
        {
            // Arrange
            var dto = new UpdateClienteDtos
            {
                IdCliente = 999,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Cliente Inexistente",
                Correo = "inexistente@example.com",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _clienteRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(dto.IdCliente))
                .ReturnsAsync((Cliente)null);

            var service = new ClienteService(
                _clienteRepositoryMock.Object,
                new Mock<IClienteMapper>().Object,
                MocksTest.GetLoggerMock<ClienteService>().Object,
                MocksTest.GetConfigurationBuilderELi()
            );

            // Act
            string message = "El cliente no existe";
            var result = await service.UpdateTipoDocumento(dto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("123A")]
        [InlineData("45-678")]
        [InlineData("78 90")]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenDocumentoIsInvalid(string documento)
        {
            // Arrange
            var clienteDto = new UpdateClienteDtos
            {
                IdCliente = 1,
                TipoDocumento = "DNI",
                Documento = documento,
                NombreCompleto = "Juan",
                Correo = "juan.perez@example.com",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _clienteRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(clienteDto.IdCliente))
                .ReturnsAsync(new Cliente());

            // Act
            string message = "El documento es inválido";
            var result = await _clienteService.UpdateTipoDocumento(clienteDto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenTipoDocumentoIsInvalid()
        {
            // Arrange
            var cliente = new UpdateClienteDtos
            {
                IdCliente = 1,
                TipoDocumento = " ",
                Documento = "12345678",
                NombreCompleto = "Juan",
                Correo = "juan.perez@example.com",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _clienteRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(cliente.IdCliente))
                .ReturnsAsync(new Cliente());

            // Act
            string message = "El cliente es tipo de documento está vacío";
            var result = await _clienteService.UpdateTipoDocumento(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateEstado

        [Theory]
        [InlineData(999, false)]
        public async Task UpdateEstado_ShouldReturnFailure_WhenClienteDoesNotExist(int idCliente, bool nuevoEstado)
        {
            // Arrange
            var dto = new UpdateClienteDtos
            {
                IdCliente = idCliente,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Cliente Inexistente",
                Correo = "inexistente@example.com",
                Estado = nuevoEstado,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _clienteRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(dto.IdCliente))
                .ReturnsAsync((Cliente)null);

            var service = new ClienteService(
                _clienteRepositoryMock.Object,
                new Mock<IClienteMapper>().Object,
                MocksTest.GetLoggerMock<ClienteService>().Object,
                MocksTest.GetConfigurationBuilderELi()
            );

            // Act
            string message = "El cliente no existe";
            var result = await service.UpdateEstado(dto, nuevoEstado);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Remove

        [Fact]
        public async Task Remove_ShouldReturnFailure_WhenClienteNotFoundOrAlreadyDeleted()
        {
            // Arrange
            var dto = new RemoveClienteDtos
            {
                IdCliente = 2,
                Borrado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _clienteRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(dto.IdCliente))
                .ReturnsAsync((Cliente)null);

            string message = "El cliente no está registrado o ya ha sido eliminado";
            var result = await _clienteService.Remove(dto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}