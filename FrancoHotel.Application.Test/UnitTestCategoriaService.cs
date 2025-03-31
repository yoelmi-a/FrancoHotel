using FrancoHotel.Application.Dtos.CategoriaDtos;
using FrancoHotel.Application.Dtos.ClienteDtos;
using FrancoHotel.Application.Mappers.Interfaces;
using FrancoHotel.Application.Services;
using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using Moq;
using System.Linq.Expressions;

namespace FrancoHotel.Application.Test
{
    public class UnitTestCategoriaService
    {
        private readonly CategoriaService _categoriaService;
        private readonly Mock<ICategoriaRepository> _categoriaRepositoryMock;
        private readonly Mock<IHabitacionRepository> _habitacionRepositoryMock;
        private readonly Mock<ICategoriaMapper> _categoriaMapperMock;

        public UnitTestCategoriaService()
        {
            _categoriaRepositoryMock = new Mock<ICategoriaRepository>();
            _habitacionRepositoryMock = new Mock<IHabitacionRepository>();
            _categoriaMapperMock = new Mock<ICategoriaMapper>();

            _categoriaService = new CategoriaService(
                _categoriaRepositoryMock.Object,
                _habitacionRepositoryMock.Object,
                MocksTest.GetLoggerMock<CategoriaService>().Object,
                MocksTest.GetConfigurationBuilderELi(),
                _categoriaMapperMock.Object
            );
        }

        //Save

        [Fact]
        public async void Save_ShouldReturnFailure_WhenClienteIsNull()
        {
            // Arrange
            SaveCategoriaDto categoria = null;

            // Act
            string message = "Los datos de la categoria son inválidos";
            var result = await _categoriaService.Save(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("123A")]
        [InlineData("45-678")]
        [InlineData("78 90")]
        public async void Save_ShouldReturnFailure_WhenDocumentoIsInvalid(string descripcion)
        {
            // Arrange
            SaveCategoriaDto categoria = new SaveCategoriaDto
            {
                Descripcion = descripcion,
                Estado = true,
                Usuario = 1
            };

            // Act
            string message = "La descripción de la categoría es inválida";
            var result = await _categoriaService.Save(categoria);

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
            UpdateCategoriaDto categoria = null;

            // Act
            string message = "Los datos de la categoria son inválidos";
            var result = await _categoriaService.Update(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData("123A")]
        [InlineData("45-678")]
        [InlineData("78 90")]
        public async void Update_ShouldReturnFailure_WhenDocumentoIsInvalid(string descripcion)
        {
            // Arrange
            UpdateCategoriaDto categoria = new UpdateCategoriaDto
            {
                Id = 1,
                Descripcion = descripcion,
                Estado = true,
                Usuario = 1
            };

            // Act
            string message = "La descripción de la categoría es inválida";
            var result = await _categoriaService.Update(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Remove

        [Fact]
        public async void Remove_ShouldReturnFailure_WhenCategoryHasAssociatedRooms()
        {
            // Arrange
            var dto = new RemoveCategoriaDto { Id = 1 };

            _habitacionRepositoryMock
                .Setup(x => x.Exists(It.IsAny<Expression<Func<Habitacion, bool>>>()))
                .ReturnsAsync(true);

            // Act
            var result = await _categoriaService.Remove(dto);
            string message = "La categoría no se puede remover porque tiene habitaciones asociadas";

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void Remove_ShouldReturnFailure_WhenCategoryNotFound()
        {
            // Arrange
            var dto = new RemoveCategoriaDto { Id = 1 };

            _habitacionRepositoryMock
                .Setup(x => x.Exists(It.IsAny<Expression<Func<Habitacion, bool>>>()))
                .ReturnsAsync(false);

            _categoriaRepositoryMock
                .Setup(x => x.GetEntityByIdAsync(dto.Id))
                .ReturnsAsync((Categoria)null);

            // Act
            var result = await _categoriaService.Remove(dto);
            string message = "No se pudo encontrar la categoría a remover";

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }
    }
}