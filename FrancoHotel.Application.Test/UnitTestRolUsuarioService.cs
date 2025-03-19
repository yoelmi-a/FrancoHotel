using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Dtos.RolUsuariosDtos;
using FrancoHotel.Application.Dtos.UsuariosDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FrancoHotel.Application.Test
{
    public class UnitTestRolUsuarioService
    {
        private Mock<IRolUsuarioRepository> _rolUsuarioRepositoryMock;
        private Mock<IRolUsuarioMapper> _rolUsusarioMapperMock;
        private RolUsuarioService _rolUsuarioService;

        public UnitTestRolUsuarioService()
        {
            _rolUsuarioRepositoryMock = new Mock<IRolUsuarioRepository>();
            _rolUsusarioMapperMock = new Mock<IRolUsuarioMapper>();
            _rolUsuarioService = new RolUsuarioService(
                _rolUsuarioRepositoryMock.Object,
                _rolUsusarioMapperMock.Object,
                MocksTest.GetConfigurationBuilderELi()
            );
        }

        //Save

        [Fact]
        public async void Save_ShouldReturnFailure_WhenUsuarioIsNull()
        {
            // Arrange
            SaveRolUsuarioDtos rolUsuario = null;

            // Act
            string message = "Los datos del rol de usuario son inválidos";
            var result = await _rolUsuarioService.Save(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Save_ShouldReturnFailure_WhenDescripcionIsInvalid()
        {
            // Arrange
            var rolUsuario = new SaveRolUsuarioDtos
            {
                Descripcion = " ",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            // Act
            string message = "La descripción no puede estar vacía";
            var result = await _rolUsuarioService.Save(rolUsuario);

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
            UpdateRolUsuarioDtos rolUsuario = null;

            // Act
            string message = "Los datos del rol de usuario son inválidos";
            var result = await _rolUsuarioService.Update(rolUsuario);

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
            var usuario = new UpdateRolUsuarioDtos
            {
                IdRolUsuario = id,
                Descripcion = "Juena",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            // Act
            string message = "El identificador del rol es obligatorio";
            var result = await _rolUsuarioService.Update(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Update_ShouldReturnFailure_WhenRolNotFound()
        {
            // Arrange
            var usuario = new UpdateRolUsuarioDtos
            {
                IdRolUsuario = 1,
                Descripcion = "Test",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _rolUsuarioRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(usuario.IdRolUsuario.Value))
                .ReturnsAsync((RolUsuario)null);

            // Act
            string message = "Rol de usuario no encontrado";
            var result = await _rolUsuarioService.Update(usuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Update_ShouldReturnFailure_WhenDescripcionIsInvalid()
        {
            // Arrange
            var rolUsuario = new UpdateRolUsuarioDtos
            {
                IdRolUsuario = 1,
                Descripcion = " ",
                Estado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            var rolExistente = new RolUsuario
            {
                Id = 1,
                Descripcion = "Rol existente"
            };

            _rolUsuarioRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(rolUsuario.IdRolUsuario.Value))
                .ReturnsAsync(rolExistente);

            // Act
            string message = "La descripción no puede estar vacía";
            var result = await _rolUsuarioService.Update(rolUsuario);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateDescripcion

        [Fact]
        public async void UpdateDescripcion_ShouldReturnFailure_WhenNuevaDescripcionIsInvalid()
        {
            // Arrange
            var rol = new RolUsuario
            {
                Id = 1,
                Descripcion = "Descripción antigua"
            };
            string nuevaDescripcion = " ";

            // Act
            string message = "La nueva descripción no puede estar vacía";
            var result = await _rolUsuarioService.UpdateDescripcion(rol, nuevaDescripcion);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //UpdateEstado

        [Fact]
        public async void UpdateEstado_ShouldReturnFailure_WhenRolNotFound()
        {
            // Arrange
            var rol = new RolUsuario
            {
                Id = 1
            };

            _rolUsuarioRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(rol.Id))
                .ReturnsAsync((RolUsuario)null);

            // Act
            string message = "El rol de usuario no existe en el servicio";
            var result = await _rolUsuarioService.UpdateEstado(rol, true);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Remove

        [Fact]
        public async void Remove_ShouldReturnFailure_WhenClienteNotFoundOrAlreadyDeleted()
        {
            // Arrange
            var dto = new RemoveRolUsuarioDtos
            {
                IdRolUsuario = 1,
                Borrado = true,
                Fecha = DateTime.Now,
                Usuario = 1
            };

            _rolUsuarioRepositoryMock
                .Setup(repo => repo.GetEntityByIdAsync(dto.IdRolUsuario))
                .ReturnsAsync((RolUsuario)null);

            string message = "Rol de usuario no encontrado";
            var result = await _rolUsuarioService.Remove(dto);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}
