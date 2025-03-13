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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
            //Arrange
            var rolUsuario = new RolUsuario
            {
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
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = " "
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
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación."
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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                Id = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                UsuarioMod = id
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNull()
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            //Arrange
            var rolUsuario = new RolUsuario
            {
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = " "
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación."
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                Id = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                UsuarioMod = id
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
        public async void UpdateDescripcion_ShouldReturnFailure_WhenRolUsuarioIsNull()
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
        public async void UpdateDescripcion_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void UpdateDescripcion_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            //Arrange
            var rolUsuario = new RolUsuario
            {
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
        public async void UpdateDescripcion_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = " "
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
        public async void UpdateDescripcion_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación."
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                Id = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                UsuarioMod = id
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
        public async void UpdateEstado_ShouldReturnFailure_WhenRolUsuarioIsNull()
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
        public async void UpdateEstado_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            //Arrange
            var rolUsuario = new RolUsuario
            {
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

        //RemoveEntityAsync

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            //Arrange
            var rolUsuario = new RolUsuario
            {
                Id = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                UsuarioMod = id
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNull()
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenRolUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var rolUsuario = new RolUsuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
                Borrado = null
            };

            // Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            //Arrange
            var rolUsuario = new RolUsuario
            {
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = " "
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var rolUsuario = new RolUsuario()
            {
                Descripcion = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación."
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

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
            //Arrange
            var rolUsuario = new RolUsuario
            {
                BorradoPorU = id
            };

            //Act
            string message = "Datos inválidos para la operación en RolUsuarioRepository";
            var result = await _rolUsuarioRepository.SaveEntityAsync(rolUsuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
