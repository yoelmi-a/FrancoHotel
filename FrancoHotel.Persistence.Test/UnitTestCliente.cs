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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
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
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = " ",
                Documento = " ",
                NombreCompleto = " ",
                Correo = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

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
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNIDNIDNIDNIDNIDNI",
                Documento = "1234567812345678",
                NombreCompleto = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

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
            Cliente cliente = new Cliente
            {
                Id = id,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

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
            Cliente cliente = new Cliente
            {
                Id = id,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id

            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

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
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenClienteEstadoYFechaIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = " ",
                Documento = " ",
                NombreCompleto = " ",
                Correo = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNIDNIDNIDNIDNIDNI",
                Documento = "1234567812345678",
                NombreCompleto = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEntityAsync(cliente);

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
            Cliente cliente = new Cliente
            {
                Id = id,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };
            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

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
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = " ",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateTipoDocumento_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNIDNIDNIDNIDNIDNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateTipoDocumento(cliente);

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
            Cliente cliente = new Cliente
            {
                Id = id,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEstado(cliente, false);

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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEstado(cliente, false);

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
            var result = await _clienteRepository.UpdateEstado(cliente, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEstado(cliente, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.UpdateEstado(cliente, false);

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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.RemoveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = id,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.RemoveEntityAsync(cliente);

            //Assert
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
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                BorradoPorU = id
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.RemoveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenClienteFechaModificacionIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.RemoveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenClienteBorradoIsNull()
        {
            // Arrange
            Cliente cliente = new Cliente
            {
                Id = 1,
                TipoDocumento = "DNI",
                Documento = "12345678",
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                Borrado = null
            };

            // Act
            string message = "Datos inválidos para la operación en ClienteRepository";
            var result = await _clienteRepository.RemoveEntityAsync(cliente);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}