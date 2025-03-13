using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestCliente
    {
        private readonly ClienteRepository _clienteRepository;
        public UnitTestCliente()
        {
            var mockLogger = MocksTest.GetLoggerMock<ClienteRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _clienteRepository = new ClienteRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //SaveEntityAsync

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenClienteEstadoYFechaIsNull()
        {
            // Arrange
            var cliente = new Cliente
            {
                EstadoYFecha = new BaseEstadoYFecha { Estado = null, FechaCreacion = null }
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = " ", Documento = " ", NombreCompleto = " ", Correo = " " };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = "DNIDNIDNIDNIDNIDNI", Documento = "1234567812345678", NombreCompleto = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.", Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación." };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var cliente = new Cliente { Id = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateEntityAsync

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var cliente = new Cliente { Id = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var cliente = new Cliente { UsuarioMod = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenClienteEstadoYFechaIsNull()
        {
            // Arrange
            var cliente = new Cliente
            {
                EstadoYFecha = new BaseEstadoYFecha { Estado = null, FechaCreacion = null }
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            var cliente = new Cliente { FechaModificacion = null };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = " ", Documento = " ", NombreCompleto = " ", Correo = " " };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = "DNIDNIDNIDNIDNIDNI", Documento = "1234567812345678", NombreCompleto = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación", Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación" };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateTipoDocumento

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var cliente = new Cliente { Id = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var cliente = new Cliente { UsuarioMod = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            var cliente = new Cliente { FechaModificacion = null };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = " " };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrage
            var cliente = new Cliente { TipoDocumento = "DNIDNIDNIDNIDNIDNI"};

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateEstado

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var cliente = new Cliente { Id = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var cliente = new Cliente { UsuarioMod = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            Cliente cliente = null;

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            var cliente = new Cliente { FechaModificacion = null };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrage
            var cliente = new Cliente()
            {
                EstadoYFecha = new BaseEstadoYFecha { Estado = null }
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //RemoveEntityAsync

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var cliente = new Cliente { UsuarioMod = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidBorradoPorU(int id)
        {
            // Arrange
            var cliente = new Cliente { BorradoPorU = id };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            var cliente = new Cliente { FechaModificacion = null };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenClienteBorradoIsNull()
        {
            // Arrange
            var cliente = new Cliente { Borrado = null };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.SaveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}