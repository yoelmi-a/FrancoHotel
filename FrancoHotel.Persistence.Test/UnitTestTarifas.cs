using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestTarifas
    {
        private readonly TarifasRepository _tarifasRepository;
        public UnitTestTarifas()
        {
            var mockLogger = MocksTest.GetLoggerMock<TarifasRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilderGerardo();
            var mockContext = MocksTest.GetContextInMemory();
            _tarifasRepository = new TarifasRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        //---------------------//
        //SaveEntityAsync
        //--------------------//

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenTarifasIsNull()
        {
            // Arrange
            Tarifas tarifas = null;

            // Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenTarifasIdCategoriaIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                IdCategoria = id
            };

            //Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenTarifasFechaInicioIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaInicio = null
            };

            // Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenTarifasFechaFinIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaFin = null
            };

            // Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShoulRetunrFailure_WhenTarifasPrecioPorNocheIsNull(int precio)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                PrecioPorNoche = precio
            };

            //Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void SaveEntityAsync_ShoulRetunrFailure_WhenTarifasDescuentoIsNull(int descuento)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descuento = descuento
            };

            //Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShoulRetunrFailure_WhenTarifasDescripcionIsGreaterThan50()
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descripcion = new string('a', 50)
            };

            //Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShoulRetunrFailure_WhenTarifasEstadoIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                Estado = "Desconocido"
            };

            //Act
            string message = "Error al crear Tarifas por datos invalidos";
            var result = await _tarifasRepository.SaveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        //---------------------//
        //UpdateEntityAsync
        //--------------------//

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasIsNull()
        {
            // Arrange
            Tarifas tarifas = null;

            // Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasIdCategoriaIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                IdCategoria = id
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasFechaInicioIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaInicio = null
            };

            // Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasFechaFinIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaFin = null
            };

            // Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShoulRetunrFailure_WhenTarifasPrecioPorNocheIsNull(int precio)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                PrecioPorNoche = precio
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void UpdateEntityAsync_ShoulRetunrFailure_WhenTarifasDescuentoIsNull(int descuento)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descuento = descuento
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShoulRetunrFailure_WhenTarifasDescripcionIsGreaterThan50()
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descripcion = new string('a', 50)
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShoulRetunrFailure_WhenTarifasEstadoIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                Estado = "Desconocido"
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasIdIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Id = id
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasUsuarioModIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                UsuarioMod = id
            };

            //Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenTarifasFechaModificacionIsNull()
        {
            // Arrange
            var tarifas = new Tarifas { FechaModificacion = null };

            // Act
            string message = "Error al actualizar Tarifas por datos invalidos";
            var result = await _tarifasRepository.UpdateEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }


        //---------------------//
        //RemoveEntityAsync
        //--------------------//

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasIsNull()
        {
            // Arrange
            Tarifas tarifas = null;

            // Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasIdCategoriaIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                IdCategoria = id
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasFechaInicioIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaInicio = null
            };

            // Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasFechaFinIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                FechaFin = null
            };

            // Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShoulRetunrFailure_WhenTarifasPrecioPorNocheIsNull(int precio)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                PrecioPorNoche = precio
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(999999999)]
        public async void RemoveEntityAsync_ShoulRetunrFailure_WhenTarifasDescuentoIsNull(int descuento)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descuento = descuento
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShoulRetunrFailure_WhenTarifasDescripcionIsGreaterThan50()
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Descripcion = new string('a', 50)
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShoulRetunrFailure_WhenTarifasEstadoIsNull()
        {
            // Arrange
            var tarifas = new Tarifas
            {
                Estado = "Desconocido"
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasIdIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                Id = id
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasBorradoPorUIsLessThan1(int id)
        {
            //Arrange
            var tarifas = new Tarifas
            {
                BorradoPorU = id
            };

            //Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenTarifasFechaModificacionIsNull()
        {
            // Arrange
            var tarifas = new Tarifas { FechaModificacion = null };

            // Act
            string message = "Error al borrar Tarifas por datos invalidos";
            var result = await _tarifasRepository.RemoveEntityAsync(tarifas);

            // Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

    }
}
