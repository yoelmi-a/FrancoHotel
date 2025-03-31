using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Interfaces;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestCategoria
    {
        private readonly CategoriaRepository _categoriaRepository;
        public UnitTestCategoria()
        {
            var mockLogger = MocksTest.GetLoggerMock<CategoriaRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderELi();
            var mockContext = MocksTest.GetContextInMemory();
            _categoriaRepository = new CategoriaRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //Save

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenCategoriaIsNull()
        {

            //Arange
            Categoria categoria = null;

            //Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.SaveEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            Categoria categoria = new Categoria
            {
                Id = id,
                Descripcion = "Habitación con cama matrimonial",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.SaveEntityAsync(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Categoria categoria = new Categoria
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
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.SaveEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Update

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenCategoriaIsNull()
        {

            //Arange
            Categoria categoria = null;

            //Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.UpdateEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            Categoria categoria = new Categoria
            {
                Id = id,
                Descripcion = "Habitación con cama matrimonial",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.UpdateEntityAsync(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Categoria categoria = new Categoria
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
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.UpdateEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //Remove

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenCategoriaIsNull()
        {

            //Arange
            Categoria categoria = null;

            //Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.RemoveEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenIdIsInvalid(int id)
        {
            // Arrange
            Categoria categoria = new Categoria
            {
                Id = id,
                Descripcion = "Habitación con cama matrimonial",
                EstadoYFecha = new BaseEstadoYFecha
                {
                    Estado = true,
                    FechaCreacion = DateTime.UtcNow
                },
                CreadorPorU = 1
            };

            // Act
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.RemoveEntityAsync(categoria);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenStringIsEmpty()
        {
            // Arrange
            Categoria categoria = new Categoria
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
            string message = "Los datos de la categoría no son válidos";
            var result = await _categoriaRepository.RemoveEntityAsync(categoria);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

    }
}
