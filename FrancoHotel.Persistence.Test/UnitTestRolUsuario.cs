using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestRolUsuario
    {
        private readonly RolUsuarioRepository _rolUsuarioRepository;
        public UnitTestRolUsuario()
        {
            var mockLogger = MocksTest.GetLoggerMock<RolUsuarioRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _rolUsuarioRepository = new RolUsuarioRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //SaveEntityAsync

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNull()
        {
            // Arrange
            RolUsuario rolUsuario = null;

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenRolUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador", 
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,      
                    FechaCreacion = null 
                },
                CreadorPorU = 1 
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = id,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNull()
        {
            // Arrange
            RolUsuario rolUsuario = null;

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRolUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateDescripcion

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = id,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenRolUsuarioIsNull()
        {
            // Arrange
            RolUsuario rolUsuario = null;

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenRolUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateDescripcion(rolUsuario, "Descripción de prueba");

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
            var rolUsuario = new RolUsuario()
            {
                Id = id,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            //Assert
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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenRolUsuarioIsNull()
        {
            // Arrange
            RolUsuario rolUsuario = null;

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenRolUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.UpdateEstado(rolUsuario, false);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //RemoveEntityAsync

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = id,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            //Assert
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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNull()
        {
            // Arrange
            RolUsuario rolUsuario = null;

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNullBorrado()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                Borrado = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = " ",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

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
            var rolUsuario = new RolUsuario()
            {
                Id = 1,
                Descripcion = "Administrador",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1,
                BorradoPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.RemoveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
