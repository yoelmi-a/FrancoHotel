using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Moq;

namespace FrancoHotel.Application.Test
{
    public class UnitTestUsuarioService
    {
        private readonly UsuarioService _usuarioService;
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock;
        private readonly Mock<IRolUsuarioRepository> _rolUsuarioRepositoryMock;
        private readonly Mock<IUsuarioMapper> _usuarioMapperMock;
        public UnitTestUsuarioService()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioRepository>();
            _rolUsuarioRepositoryMock = new Mock<IRolUsuarioRepository>();
            _usuarioMapperMock = new Mock<IUsuarioMapper>();
            _usuarioService = new UsuarioService(
                _usuarioRepositoryMock.Object,
                _rolUsuarioRepositoryMock.Object,
                _usuarioMapperMock.Object,
                MocksTest.GetConfigurationBuilderELi()
            );
        }

        //Save

        [Fact]
        public async void Save_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            SaveUsuarioDtos usuario = null;

            // Act
            string message = "Los datos del usuario son inválidos";
            var result = await _usuarioService.Save(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("María123")]
        [InlineData("José-Pérez")]
        [InlineData("Luís_Álvarez")]
        [InlineData("Ana!")]
        [InlineData("Juan@")]
        [InlineData("Claudia#")]
        [InlineData("María López3")]
        [InlineData("Juan3 Carlos")]
        public async void Save_ShouldReturnFailure_WhenNombreIsInvalid(string nombre)
        {
            // Arrange
            SaveUsuarioDtos usuario = new SaveUsuarioDtos
            {
                NombreCompleto = nombre,
                Clave = "123456",
                Correo = "juan.perez@example.com",
                IdRolUsuario = 1
            };

            // Act
            string message = "El nombre completo es inválido";
            var result = await _usuarioService.Save(usuario);

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
            SaveUsuarioDtos usuario = new SaveUsuarioDtos
            {
                NombreCompleto = "Juan",
                Clave = "123456",
                Correo = correo,
                IdRolUsuario = 1
            };

            // Act
            string message = "El correo es inválido";
            var result = await _usuarioService.Save(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Update

        [Fact]
        public async void Update_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            UpdateUsuarioDtos usuario = null;

            // Act
            string message = "Los datos del usuario son inválidos";
            var result = await _usuarioService.Update(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void Update_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            UpdateUsuarioDtos usuario = new UpdateUsuarioDtos
            {
                IdUsuario = id,
                NombreCompleto = "Juan",
                Clave = "123456",
                Correo = "juan.perez@example.com"
            };

            // Act
            string message = "El identificador de usuario es obligatorio";
            var result = await _usuarioService.Update(usuario);

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
            var usuario = new UpdateUsuarioDtos
            {
                IdUsuario = 1,
                NombreCompleto = "Juan",
                Clave = "123456",
                Correo = correo,
                IdRolUsuario = 1
            };

            _usuarioRepositoryMock
                .Setup(r => r.GetEntityByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(new Usuario { Id = 1, Borrado = false });


            // Act
            string message = "El correo es inválido";
            var result = await _usuarioService.Update(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Update_ShouldReturnFailure_WhenUsuarioNotFound()
        {
            // Arrange
            var dto = new UpdateUsuarioDtos
            {
                IdUsuario = 1,
                NombreCompleto = "Juan Pérez",
                Clave = "clave123",
                Correo = "juan@example.com"
            };

            _usuarioRepositoryMock
                .Setup(r => r.GetEntityByIdAsync(dto.IdUsuario))
                .ReturnsAsync((Usuario)null);

            // Act
            string message = "Usuario no encontrado";
            var result = await _usuarioService.Update(dto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Update_ShouldReturnFailure_WhenUsuarioIsBorrado()
        {
            // Arrange
            var dto = new UpdateUsuarioDtos
            {
                IdUsuario = 2,
                NombreCompleto = "María López",
                Clave = "clave123",
                Correo = "maria@example.com"
            };

            var usuarioBorrado = new Usuario
            {
                Id = dto.IdUsuario,
                Borrado = true,
            };

            _usuarioRepositoryMock
                .Setup(r => r.GetEntityByIdAsync(dto.IdUsuario))
                .ReturnsAsync(usuarioBorrado);

            // Act
            string message = "Usuario no encontrado";
            var result = await _usuarioService.Update(dto);

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
            var dto = new RemoveUsuarioDtos
            {
                IdUsuario = 1,
                Borrado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _usuarioRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(dto.IdUsuario))
                .ReturnsAsync((Usuario)null);

            string message = "El usuario no está registrado o ya ha sido eliminado";
            var result = await _usuarioService.Remove(dto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}