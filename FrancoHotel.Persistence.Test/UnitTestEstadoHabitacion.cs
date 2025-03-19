using FrancoHotel.Application.Test;
using FrancoHotel.Domain.Base;
using FrancoHotel.Domain.Entities;
using FrancoHotel.Persistence.Repositories;

namespace FrancoHotel.Persistence.Test
{
    public class UnitTestEstadoHabitacion
    {
        private readonly EstadoHabitacionRepository _repository;

        public UnitTestEstadoHabitacion()
        {
            var mockLogger = MocksTest.GetLoggerMock<EstadoHabitacionRepository>();
            var mockConfiguration = MocksTest.GetConfigurationBuilder();
            var mockContext = MocksTest.GetContextInMemory();
            _repository = new EstadoHabitacionRepository(mockContext, mockLogger.Object, mockConfiguration);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenEstadoHabitacionIsNull()
        {

            //Arange

            EstadoHabitacion estado = null;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = data;
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = new string('a', 51);
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = null;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = null;
            estado.CreadorPorU = 1;
            estado.Borrado = false;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenEstadoHabitacionIsNull()
        {

            //Arange

            EstadoHabitacion estado = null;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = data;
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = new string('a', 51);
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = null;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = null;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenUsuarioModIsLessThan1(int data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = data;
            estado.FechaModificacion = DateTime.Now;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = null;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenEstadoHabitacionIsNull()
        {

            //Arange

            EstadoHabitacion estado = null;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDescripcionIsNull(string data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = data;
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenDescripcionIsTooLong()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = new string('a', 51);
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenEstadoIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = null;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaCreacionIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = null;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenUsuarioModIsLessThan1(int data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = data;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenFechaModificacionIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = null;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoIsNull()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = null;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async void RemoveEntityAsync_ShouldReturnFailure_WhenBorradoPorUIsLessThan1(int data)
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = data;

            //Act
            string message = "Los datos de el estado de habitación no son válidos";
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.False(result.Success);
            Assert.Equal(message, result.Message);
        }

        [Fact]
        public async void RemoveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            await _repository.SaveEntityAsync(estado);

            estado.Borrado = true;
            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;
            estado.BorradoPorU = 1;

            //Act
            var result = await _repository.RemoveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void UpdateEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;
            await _repository.SaveEntityAsync(estado);

            estado.UsuarioMod = 1;
            estado.FechaModificacion = DateTime.Now;

            //Act
            var result = await _repository.UpdateEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async void SaveEntityAsync_ShouldReturnTrue_WhenDataIsCorrect()
        {

            //Arange
            EstadoHabitacion estado = new EstadoHabitacion();
            estado.Descripcion = "Descripcion";
            estado.EstadoYFecha.Estado = true;
            estado.EstadoYFecha.FechaCreacion = DateTime.Now;
            estado.CreadorPorU = 1;
            estado.Borrado = false;

            //Act
            var result = await _repository.SaveEntityAsync(estado);

            //Assert
            Assert.IsType<OperationResult>(result);
            Assert.True(result.Success);
        }
    }
}
