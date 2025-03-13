﻿using FrancoHotel.Application.Test;
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
                EstadoYFecha = new BaseEstadoYFecha 
                { 
                    Estado = null, 
                    FechaCreacion = null
                }
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
            //Arrange
            var usuario = new Usuario 
            { 
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
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = " ", 
                Correo = " ", 
                Clave = " "
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
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación", 
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.", 
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
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
            //Arrange
            var usuario = new Usuario 
            {
                Id = id 
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
            var usuario = new Usuario 
            { 
                UsuarioMod = id 
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario() 
            { 
                FechaModificacion = null 
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
                EstadoYFecha = new BaseEstadoYFecha 
                { 
                    Estado = null, 
                    FechaCreacion = null 
                }
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalidCreadorPorU(int id)
        {
            //Arrange
            var usuario = new Usuario 
            { 
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = " ",
                Correo = " ",
                Clave = " "
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
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
            //Arrange
            var usuario = new Usuario
            {
                UsuarioMod = id
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
        public async void UpdateClave_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void UpdateClave_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            //Arrange
            var usuario = new Usuario
            {
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
        public async void UpdateClave_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Clave = " "
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
        public async void UpdateClave_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
            //Arrange
            var usuario = new Usuario
            {
                UsuarioMod = id
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
        public async void UpdateEstado_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                FechaModificacion = null
            };

            // Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

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
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void UpdateEstado_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            //Arrange
            var usuario = new Usuario
            {
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

        //RemoveEntityAsync

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioIsNull()
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioEstadoYFechaIsNull()
        {
            // Arrange
            var usuario = new Usuario()
            {
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = null,
                    FechaCreacion = null
                }
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            //Arrange
            var usuario = new Usuario
            {
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = " ",
                Correo = " ",
                Clave = " "
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsLonger()
        {
            //Arrange
            var usuario = new Usuario()
            {
                NombreCompleto = "Admin Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación",
                Correo = "Este es un texto de prueba con exactamente cien letras para que puedas utilizarlo en cualquier validación.",
                Clave = "1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890"
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioIsNullFechaModificacion()
        {
            // Arrange
            var usuario = new Usuario()
            {
                FechaModificacion = null
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
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalidUsuarioMod(int id)
        {
            //Arrange
            var usuario = new Usuario
            {
                UsuarioMod = id
            };

            //Act
            string message = "Datos inválidos para la operación en UsuarioRepository";
            var result = await _usuarioRepository.SaveEntityAsync(usuario);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
