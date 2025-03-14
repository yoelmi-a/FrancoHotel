using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestUsuario
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UnitTestUsuario()
        {
            var mockLogger = MocksTest.GetLoggerMock<UsuarioRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _usuarioRepository = new UsuarioRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //SaveEntityAsync

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            Usuario usuario = null;

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1, 
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,  
                    FechaCreacion = null 
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            // Assert
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
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = " ",
                Correo = " ",
                IdRolUsuario = 2,
                Clave = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                IdRolUsuario = 2,
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            //Assert
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
            var usuario = new Usuario()
            {
                Id = id,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            //Assert
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
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null    
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            Usuario usuario = null;

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = " ",
                Correo = " ",
                IdRolUsuario = 2,
                Clave = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                IdRolUsuario = 2,
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateClave

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateClave_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateClave_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null   
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateClave_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateClave_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateClave_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateClave_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateClave(usuario, "NuevaClaveSegura123");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateEstado

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEstado(usuario, false);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEstado(usuario, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEstado(usuario, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.UpdateEstado(usuario, false);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //RemoveEntityAsync

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            Usuario usuario = null;

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            //Assert
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
            var usuario = new Usuario()
            {
                Id = id,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = " ",
                Correo = " ",
                IdRolUsuario = 2,
                Clave = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                IdRolUsuario = 2,
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var usuario = new Usuario()
            {
                Id = 1,
                NombreCompleto = "Juan Pérez",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 2,
                Clave = "ClaveSegura123",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.RemoveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
